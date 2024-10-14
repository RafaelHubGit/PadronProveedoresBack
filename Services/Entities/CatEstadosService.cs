using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatEstadosService
    {
        private readonly CatEstadosRepository _repository;

        public CatEstadosService(CatEstadosRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatEstadosModel> ObtenerEstados()
        {
            return _repository.ObtenerEstados();
        }

        public CatEstadosModel ObtenerEstadoPorId(int idEstado)
        {
            return _repository.ObtenerEstadoPorId(idEstado);
        }
    }
}
