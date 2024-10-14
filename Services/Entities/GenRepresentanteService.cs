using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class GenRepresentanteService
    {
        private readonly GenRepresentanteRepository _repository;

        public GenRepresentanteService(GenRepresentanteRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GenRepresentanteModel> ObtenerRepresentantes()
        {
            return _repository.ObtenerRepresentantes();
        }

        public GenRepresentanteModel ObtenerRepresentantePorId(int idRepresentante)
        {
            return _repository.ObtenerRepresentantePorId(idRepresentante);
        }

        public void CrearRepresentante(GenRepresentanteModel representante)
        {
            _repository.CrearRepresentante(representante);
        }

        public void ActualizarRepresentante(GenRepresentanteModel representante)
        {
            _repository.ActualizarRepresentante(representante);
        }

        public void EliminarRepresentanteLogico(int idRepresentante, int idUsuarioModificacion)
        {
            _repository.EliminarRepresentanteLogico(idRepresentante, idUsuarioModificacion);
        }

        public void EliminarRepresentanteFisico(int idRepresentante)
        {
            _repository.EliminarRepresentanteFisico(idRepresentante);
        }
    }
}
