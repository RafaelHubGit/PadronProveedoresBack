using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatCodigosPostalesService
    {
        private readonly CatCodigosPostalesRepository _repository;

        public CatCodigosPostalesService(CatCodigosPostalesRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatCodigosPostalesModel> ObtenerCodigosPostales()
        {
            return _repository.ObtenerCodigosPostales();
        }

        public CatCodigosPostalesModel ObtenerCodigoPostalPorId(int idCodigoPostal)
        {
            return _repository.ObtenerCodigoPostalPorId(idCodigoPostal);
        }

        public IEnumerable<CatCodigosPostalesModel> ObtenerCodigosPostalesPorIdColonia(int idColonia)
        {
            return _repository.ObtenerCodigosPostalesPorIdColonia(idColonia);
        }
    }
}
