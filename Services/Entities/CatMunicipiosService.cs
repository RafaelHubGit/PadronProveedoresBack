using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatMunicipiosService
    {
        private readonly CatMunicipiosRepository _repository;

        public CatMunicipiosService(CatMunicipiosRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatMunicipiosModel> ObtenerMunicipios()
        {
            return _repository.ObtenerMunicipios();
        }

        public CatMunicipiosModel ObtenerMunicipioPorId(int idMunicipio)
        {
            return _repository.ObtenerMunicipioPorId(idMunicipio);
        }

        public IEnumerable<CatMunicipiosModel> ObtenerMunicipiosPorIdEstado(int idEstado)
        {
            return _repository.ObtenerMunicipiosPorIdEstado(idEstado);
        }
    }
}
