using System.Text.Json;
using Newtonsoft.Json;
using PadronProveedoresAPI.Data.Repository.Project;
using PadronProveedoresAPI.Models.Project;

namespace PadronProveedoresAPI.Services.Project
{
    public class ProveedorService
    {
        private readonly ProveedorRepository _repository;

        public ProveedorService (ProveedorRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> GetProveedorByNumeroProveedorAsync(string NumeroProveedor)
        {
            var jsonReponse = await _repository.GetProveedorByNumeroProveedorAsync(NumeroProveedor);
            var proveedoresString = await ReturnArrayProveedorStringAsync(jsonReponse);

            return proveedoresString;
        }

        public async Task<string> GetAllProveedoresAsync()
        {

            var jsonReponse = await _repository.GetAllProveedoresAsync();
            var proveedoresString = await ReturnArrayProveedorStringAsync(jsonReponse);

            return proveedoresString;
        }

        public async Task<string> GetProveedorScrollAsync( int offset = 0, int pageSize = 10 )
        {
            var jsonReponse = await _repository.GetProveedorScrollAsync(offset, pageSize);
            var proveedoresString = await ReturnArrayProveedorStringAsync(jsonReponse);
            
            return proveedoresString;
        }

        //Esta funcion entra al json y solo regresa el array
        private async Task<string> ReturnArrayProveedorStringAsync(string proveedoresString)
        {
            try
            {
                var jsonDoc = JsonDocument.Parse(proveedoresString);
                var root = jsonDoc.RootElement;

                // Validar que el JSON tenga la estructura esperada
                if (root.ValueKind != JsonValueKind.Array || root.GetArrayLength() == 0)
                {
                    throw new Exception("El JSON no es un array o está vacío.");
                }

                var proveedores = root[0].GetProperty("Proveedores");

                // Validar que 'Proveedores' exista
                if (proveedores.ValueKind == JsonValueKind.Undefined)
                {
                    throw new Exception("La propiedad 'Proveedores' no existe en el JSON.");
                }

                return proveedores.GetRawText() ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al parsear JSON: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
