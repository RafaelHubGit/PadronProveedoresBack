using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class GenContactoService
    {
        private readonly GenContactoRepository _repository;

        public GenContactoService(GenContactoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GenContactoModel> ObtenerContactos()
        {
            return _repository.ObtenerContactos();
        }

        public GenContactoModel ObtenerContactoPorId(int idContacto)
        {
            return _repository.ObtenerContactoPorId(idContacto);
        }

        public void CrearContacto(GenContactoModel contacto)
        {
            _repository.CrearContacto(contacto);
        }

        public void ActualizarContacto(GenContactoModel contacto)
        {
            _repository.ActualizarContacto(contacto);
        }

        public void EliminarContactoLogico(int idContacto, int idUsuarioModificacion)
        {
            _repository.EliminarContactoLogico(idContacto, idUsuarioModificacion);
        }

        public void EliminarContactoFisico(int idContacto)
        {
            _repository.EliminarContactoFisico(idContacto);
        }
    }
}
