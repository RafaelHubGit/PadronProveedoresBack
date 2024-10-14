using Newtonsoft.Json;
using PadronProveedoresAPI.Data.Repository.Project;
using System.Text;

namespace PadronProveedoresAPI.Services.Project
{
    public class TypeSenseService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly ProveedorService _service;
        public TypeSenseService(string baseUrl,
                                string apiKey,
                                ProveedorService proveedorService)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
            _httpClient.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", apiKey);
            _apiKey = apiKey;

            _service = proveedorService;
        }

        public async Task<bool> IndexaPorveedores( string collectionName = "proveedores" )
        {
            //string collectionName = "proveedores";

            await DeleteCollectionIfExistsAsync(collectionName);

            var createCollectionResult = await CreateCollectionAsync(collectionName);
            Console.WriteLine("coleccion creada : " + createCollectionResult);

            var proveedores = await _service.GetAllProveedoresAsync();

            foreach (var proveedor in proveedores)
            {
                var documentJson = JsonConvert.SerializeObject(proveedor);
                var upsertResult = await UpsertDocumentAsync(collectionName, documentJson);
                Console.WriteLine("Document Upserted: " + upsertResult);
            }

            return true;
        }

        public async Task<string> CreateCollectionAsync(string collectionName)
        {
            var schema = new
            {
                name = collectionName,
                fields = new[]
                {
                    new { name = "idProveedor", type = "int32", facet = false, optional = false },
                    new { name = "rfc", type = "string", facet = true, optional = false },
                    new { name = "razonSocial", type = "string", facet = true, optional = false },
                    new { name = "fechaAlta", type = "string", facet = false, optional = false },
                    new { name = "activo", type = "bool", facet = true, optional = false },
                    new { name = "numeroProveedor", type = "string", facet = true, optional = false },

                    new { name = "datosProveedores.numeroRefrendo", type = "string[]", facet = true, optional = true },
                    new { name = "datosProveedores.tipoProveedor", type = "string[]", facet = true, optional = true },
                    new { name = "datosProveedores.observaciones", type = "string[]", facet = false, optional = true },
                    new { name = "datosProveedores.esRepse", type = "bool", facet = true, optional = true },
                    new { name = "datosProveedores.tieneDocumentos", type = "bool", facet = true, optional = true },

                    new { name = "datosProveedores.domicilio.calle", type = "string", facet = false, optional = true },
                    new { name = "datosProveedores.domicilio.estado", type = "string", facet = true, optional = true },
                    new { name = "datosProveedores.domicilio.municipio", type = "string", facet = true, optional = true },
                    new { name = "datosProveedores.domicilio.colonia", type = "string", facet = true, optional = true },
                    new { name = "datosProveedores.domicilio.codigoPostal", type = "string", facet = true, optional = true },
                    new { name = "datosProveedores.domicilio.direccionInternacional", type = "string", facet = false, optional = true },

                    new { name = "datosProveedores.representantes.representante", type = "string[]", facet = true, optional = true },

                    new { name = "datosProveedores.contacto.contactos", type = "string[]", facet = false, optional = true },

                    new { name = "datosProveedores.girosComerciales.giroComercial", type = "string[]", facet = true, optional = true },

                    new { name = "datosProveedores.documentos.nombreDocumento", type = "string[]", facet = true, optional = true },

                    new { name = "datosProveedores.inactivo.observacion", type = "string", facet = false, optional = true },
                    new { name = "datosProveedores.inactivo.fechaInicio", type = "string", facet = false, optional = true },
                    new { name = "datosProveedores.inactivo.fechaFin", type = "string", facet = false, optional = true },
                    new { name = "datosProveedores.inactivo.fechaDiarioOficialFederacion", type = "string", facet = false, optional = true }

                }
            };

            var schemaJson = JsonConvert.SerializeObject(schema);
            var content = new StringContent(schemaJson, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("/collections", content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                // Maneja la excepción cuando la colección ya existe
                return "Collection already exists";
            }
        }

        public async Task<string> UpsertDocumentAsync(string collectionName, string documentJson)
        {
            var content = new StringContent(documentJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/collections/{collectionName}/documents", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}. Details: {errorContent}");
            }

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteCollectionIfExistsAsync(string collectionName)
        {
            var existResponse = await _httpClient.GetAsync($"/collections/{collectionName}");

            if (existResponse.IsSuccessStatusCode)
            {
                var deleteResponse = await _httpClient.DeleteAsync($"/collections/{collectionName}");
                deleteResponse.EnsureSuccessStatusCode();
                return await deleteResponse.Content.ReadAsStringAsync();
            }
            else if (existResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return $"Collection {collectionName} does not exist.";
            }
            else
            {
                var errorMessage = await existResponse.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error checking collection existence: {errorMessage}");
            }
        }
    }
}
