using PadronProveedoresAPI.Data.Repository.Project;

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
            return await _repository.GetProveedorByNumeroProveedorAsync(NumeroProveedor);
        }

        public async Task<string> GetAllProveedoresAsync()
        { 
            return await _repository.GetAllProveedoresAsync();
        }

        public async Task<string> GetProveedorScrollAsync( int offset, int pageSize )
        { 
            return await _repository.GetProveedorScrollAsync( offset, pageSize );
        }
    }
}
