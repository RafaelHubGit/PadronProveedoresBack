//using Newtonsoft.Json;
using PadronProveedoresAPI.Data.Repository.Project;
using PadronProveedoresAPI.Models.Project;
using PadronProveedoresAPI.Utilities;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using static PadronProveedoresAPI.Utilities.ProveedorTypeSenseMapping;

namespace PadronProveedoresAPI.Services.Project
{
    public class TypeSenseService
    {
        private readonly HttpClient _httpClient;
        //private readonly string _apiKey;
        private readonly ProveedorService _service;
        private readonly TypeSenseUtilities _typeSenseUtilities;
        public TypeSenseService(string baseUrl,
                                string apiKey,
                                ProveedorService proveedorService)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
            _httpClient.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", apiKey);

            _service = proveedorService;
            _typeSenseUtilities = new TypeSenseUtilities(_httpClient);
        }

        public async Task<bool> IndexaPorveedores( string collectionName = "proveedores" )
        {

            await _typeSenseUtilities.DeleteCollectionIfExistsAsync(collectionName);

            var createCollectionResult = await _typeSenseUtilities.CreateCollectionAsync(collectionName);
            Console.WriteLine("coleccion creada : " );

            //var proveedores = await _service.GetAllProveedoresAsync();
            var proveedores = await _service.GetProveedorScrollAsync(0, 2);

            // Convierte el json al modelo de Proveedores 
            var proveedoresLista = JsonSerializer.Deserialize<ProveedorModel.Proveedor[]>(proveedores);

            var mappingInstance = new ProveedorTypeSenseMapping();
            // Convierte del modelo de proveedores al modelo de TypeSense
            var proveedoresListaTypeSenseMapped = mappingInstance.MappingSchemaTypeSense(proveedoresLista.ToList());

            foreach (var proveedor in proveedoresListaTypeSenseMapped)
            {

                //Console.WriteLine($"IdProveedor: {JsonSerializer.Serialize(proveedor)}");

                var documentJson = JsonSerializer.Serialize(proveedor);

                var upsertResult = await _typeSenseUtilities.UpsertDocumentAsync(collectionName, documentJson);
                Console.WriteLine($"Document Upserted Numero de proveedor: { proveedor.numeroProveedor } --- {upsertResult}");
            }

            return true;
        }

        public async Task<string> GetAllDocumentsAsync(string collectionName = "proveedores")
        {
            var searchParameters = new SearchParameters
            {
                q = "*", // Consulta vacía para recuperar todos los documentos
                limit = 1000 // Límite de documentos por página (opcional)
                //IncludeFields = "*", // Incluir todos los campos (opcional)
            };

            var response = await _typeSenseUtilities.GetAllProveedores(collectionName, searchParameters);

            return response;
        }

        public async Task<string> GetProveedoresQuery(string collectionName = "proveedores", string query = "*",int pageNumber = 1, int pageSize = 100) 
        {
            var searchParameters = new SearchParameters 
            { 
                q = query,
                limit = pageSize,
                page = pageNumber
            };

            var response = await _typeSenseUtilities.GetProveedoresQuery(collectionName, searchParameters);

            return response;
        }


    }
}
