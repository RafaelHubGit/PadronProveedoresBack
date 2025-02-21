using System.Net.Http;
using System.Text;
using System.Text.Json;
using static PadronProveedoresAPI.Utilities.ProveedorTypeSenseMapping;
using PadronProveedoresAPI.Utilities;
using PadronProveedoresAPI.Models.Project;
using PadronProveedoresAPI.Services.Project;

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
                fields = FieldDefinitions.ProveedorFields.ToArray(),
            //{
            //    new FieldDefinition { name = "idProveedor", type = "int32", facet = false, optional = false, sort = true },
            //    new FieldDefinition { name = "rfc", type = "string", facet = true, optional = false, sort = true, infix= true },
            //    new FieldDefinition { name = "razonSocial", type = "string", facet = false, optional = false, sort = true, infix= true },
            //    new FieldDefinition { name = "fechaAlta", type = "string", facet = false, optional = false },
            //    new FieldDefinition { name = "activo", type = "bool", facet = true, optional = false, sort = true },
            //    new FieldDefinition { name = "numeroProveedor", type = "string", facet = true, optional = false, sort = true },

            //    new FieldDefinition { name = "numeroRefrendo", type = "string[]", facet = true, optional = true },
            //    new FieldDefinition { name = "tipoProveedor", type = "string[]", facet = true, optional = true },
            //    new FieldDefinition { name = "observaciones", type = "string[]", facet = false, optional = true, infix= true },
            //    new FieldDefinition { name = "esRepse", type = "bool[]", facet = true, optional = true },
            //    new FieldDefinition { name = "tieneDocumentos", type = "bool[]", facet = true, optional = true },

            //    new FieldDefinition { name = "Direccion", type = "string", facet = true, optional = true},
            //    new FieldDefinition { name = "DreccionInternacional", type = "string", facet = false, optional = true },

            //    new FieldDefinition { name = "representantes", type = "string[]", facet = true, optional = true },

            //    new FieldDefinition { name = "contactos", type = "string[]", facet = false, optional = true },

            //    new FieldDefinition { name = "girosComerciales", type = "string[]", facet = true, optional = true },

            //    new FieldDefinition { name = "documentos", type = "string[]", facet = true, optional = true },

            //    new FieldDefinition { name = "inactivoObservacion", type = "string", facet = false, optional = true },
            //    new FieldDefinition { name = "inactivoFechaInicio", type = "string", facet = false, optional = true },
            //    new FieldDefinition { name = "inactivoFechaFin", type = "string", facet = false, optional = true },
            //    new FieldDefinition { name = "inactivoFechaDOF", type = "string", facet = false, optional = true }

            //},
            default_sorting_field = "idProveedor", // Campo para ordenar resultados
                query_by = new[] { "*" }, // Permitir búsqueda en todos los campos
                case_insensitive = true
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
            var queryString = $"?q={searchParameters.q}&per_page={searchParameters.per_page}";
            var url = $"/collections/{collectionName}/documents/search{queryString}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(responseBody);

            var documents = jsonDoc.RootElement.GetProperty("hits")
                .EnumerateArray()
                .Select(hit => JsonDocument.Parse(hit.GetProperty("document").GetRawText()))
                .Select(doc => doc.RootElement)
                .ToList();

            var found = jsonDoc.RootElement.GetProperty("found").GetInt32();

            // Crear un objeto JSON con los resultados y el número de resultados encontrados
            var result = new
            {
                results = documents,
                count = found,
                returned = documents.Count
            };

            // Serializar el objeto JSON
            var json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

            return json;
        }

        public async Task<string> GetProveedoresQuery(string collectionName, SearchParameters searchParameters)
        {
            try {
                //var queryString = $"?q={searchParameters.q}&page={searchParameters.page}&per_page={searchParameters.per_page}";

                //if (!string.IsNullOrEmpty(searchParameters.query_by))
                //{
                //    queryString += $"&query_by={searchParameters.query_by}";
                //}

                var queryParams = typeof(SearchParameters)
                .GetProperties()
                .Where(p => p.GetValue(searchParameters) != null)
                .Select(p => $"{p.Name}={p.GetValue(searchParameters)?.ToString()}");

                var queryString = "?" + string.Join("&", queryParams);

                var url = $"/collections/{collectionName}/documents/search{queryString}";

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var jsonDoc = JsonDocument.Parse(responseBody);

                var documents = jsonDoc.RootElement.GetProperty("hits")
                    .EnumerateArray()
                    .Select(hit =>
                    {
                        var doc = JsonDocument.Parse(hit.GetProperty("document").GetRawText());

                        // Intentar obtener highlights, si no existen, asignar un array vacío []
                        JsonElement highlights = hit.TryGetProperty("highlights", out var h) ? h : JsonDocument.Parse("[]").RootElement;

                        return new
                        {
                            Document = doc.RootElement,
                            Highlights = highlights
                        };
                    })
                    .ToList();

                var found = jsonDoc.RootElement.GetProperty("found").GetInt32();

                // Crear un objeto JSON con los resultados y el número de resultados encontrados
                var result = new
                {
                    results = documents,
                    count = found,
                    returned = documents.Count
                };

                // Serializar el objeto JSON
                var json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

                return json;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al procesar JSON: {ex.Message}");
                return $"Error al procesar JSON: {ex.Message}";
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al realizar la solicitud HTTP: {ex.Message}");
                return $"Error al realizar la solicitud HTTP: {ex.Message}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return $"Error inesperado: {ex.Message}";
            }
        }

    }

    public class FieldDefinition
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool facet { get; set; }
        public bool optional { get; set; }
        public bool? sort { get; set; } = false;
        public bool? infix { get; set; } = false;

        public FieldDefinition()
        {
            sort ??= false; // Asegura que sort sea false si es null
            infix ??= false;
        }
    }

}
