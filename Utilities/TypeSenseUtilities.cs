using System.Net.Http;
using System.Text;
using System.Text.Json;
using static PadronProveedoresAPI.Utilities.ProveedorTypeSenseMapping;
using PadronProveedoresAPI.Utilities;
using PadronProveedoresAPI.Models.Project;

namespace PadronProveedoresAPI.Utilities
{
    public class TypeSenseUtilities
    {
        private readonly HttpClient _httpClient;

        public TypeSenseUtilities(HttpClient httpClient) {
            _httpClient = httpClient;
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
                    new { name = "datosProveedores.esRepse", type = "bool[]", facet = true, optional = true },
                    new { name = "datosProveedores.tieneDocumentos", type = "bool[]", facet = true, optional = true },

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

                },
                default_sorting_field = "idProveedor", // Campo para ordenar resultados
                query_by = new[] { "*" } // Permitir búsqueda en todos los campos
            };

            var schemaJson = JsonSerializer.Serialize(schema);
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

        public async Task<string> GetAllProveedores(string collectionName, SearchParameters searchParameters)
        {
            var queryString = $"?q={searchParameters.q}&limit={searchParameters.limit}";
            var url = $"/collections/{collectionName}/documents/search{queryString}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(responseBody);

            var documents = jsonDoc.RootElement.GetProperty("hits")
                .EnumerateArray()
                .Select(hit => hit.GetProperty("document").GetRawText())
                .ToList();

            var documentsStr = string.Join(", ", documents);

            return documentsStr;
        }

        public async Task<string> GetProveedoresQuery(string collectionName, SearchParameters searchParameters)
        {
            var queryString = $"?q={searchParameters.q}&page={searchParameters.page}&limit={searchParameters.limit}";

            if (!string.IsNullOrEmpty(searchParameters.query_by))
            {
                queryString += $"&query_by={searchParameters.query_by}";
            }

            var url = $"/collections/{collectionName}/documents/search{queryString}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(responseBody);

            var documents = jsonDoc.RootElement.GetProperty("hits")
                .EnumerateArray()
                .Select(hit => hit.GetProperty("document").GetRawText())
                .ToList();

            var documentsStr = string.Join(", ", documents);
            //var documentsJson = JsonSerializer.Serialize(documents);

            return documentsStr;
        }

    }
    
}
