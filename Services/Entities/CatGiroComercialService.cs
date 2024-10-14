using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatGiroComercialService
    {
        private readonly CatGiroComercialRepository _repository;

        public CatGiroComercialService(CatGiroComercialRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatGiroComercialModel> ObtenerGirosComerciales()
        {
            return _repository.ObtenerGirosComerciales();
        }

        public CatGiroComercialModel ObtenerGiroComercialPorId(int idGiroComercial)
        {
            return _repository.ObtenerGiroComercialPorId(idGiroComercial);
        }

        public void CrearGiroComercial(CatGiroComercialModel giroComercial)
        {
            _repository.CrearGiroComercial(giroComercial);
        }

        public void ActualizarGiroComercial(CatGiroComercialModel giroComercial)
        {
            _repository.ActualizarGiroComercial(giroComercial);
        }

        public void EliminarGiroComercialLogico(int idGiroComercial)
        {
            _repository.EliminarGiroComercialLogico(idGiroComercial);
        }

        public void EliminarGiroComercialFisico(int idGiroComercial)
        {
            _repository.EliminarGiroComercialFisico(idGiroComercial);
        }
    }
}
