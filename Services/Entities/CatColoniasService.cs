using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatColoniasService
    {
        private readonly CatColoniasRepository _repository;

        public CatColoniasService(CatColoniasRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatColoniasModel> ObtenerColonias()
        {
            return _repository.ObtenerColonias();
        }

        public CatColoniasModel ObtenerColoniaPorId(int idColonia)
        {
            return _repository.ObtenerColoniaPorId(idColonia);
        }

        public IEnumerable<CatColoniasModel> ObtenerColoniasPorIdMunicipio(int idMunicipio)
        {
            return _repository.ObtenerColoniasPorIdMunicipio(idMunicipio);
        }
    }
}
