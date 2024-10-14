using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class GenDomicilioService
    {
        private readonly GenDomicilioRepository _repository;

        public GenDomicilioService(GenDomicilioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GenDomicilioModel> ObtenerDomicilios()
        {
            return _repository.ObtenerDomicilios();
        }

        public GenDomicilioModel ObtenerDomicilioPorId(int idDomicilio)
        {
            return _repository.ObtenerDomicilioPorId(idDomicilio);
        }

        public void CrearDomicilio(GenDomicilioModel domicilio)
        {
            _repository.CrearDomicilio(domicilio);
        }

        public void ActualizarDomicilio(GenDomicilioModel domicilio)
        {
            _repository.ActualizarDomicilio(domicilio);
        }

        public void EliminarDomicilioLogico(int idDomicilio, int idUsuarioModificacion)
        {
            _repository.EliminarDomicilioLogico(idDomicilio, idUsuarioModificacion);
        }

        public void EliminarDomicilioFisico(int idDomicilio)
        {
            _repository.EliminarDomicilioFisico(idDomicilio);
        }
    }
}
