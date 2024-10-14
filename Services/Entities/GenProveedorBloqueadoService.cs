using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class GenProveedorBloqueadoService
    {
        private readonly GenProveedorBloqueadoRepository _repository;

        public GenProveedorBloqueadoService(GenProveedorBloqueadoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GenProveedorBloqueadoModel> ObtenerProveedoresBloqueados()
        {
            return _repository.ObtenerProveedoresBloqueados();
        }

        public GenProveedorBloqueadoModel ObtenerProveedorBloqueadoPorId(int idProveedorBloqueado)
        {
            return _repository.ObtenerProveedorBloqueadoPorId(idProveedorBloqueado);
        }

        public void CrearProveedorBloqueado(GenProveedorBloqueadoModel proveedorBloqueado)
        {
            _repository.CrearProveedorBloqueado(proveedorBloqueado);
        }

        public void ActualizarProveedorBloqueado(GenProveedorBloqueadoModel proveedorBloqueado)
        {
            _repository.ActualizarProveedorBloqueado(proveedorBloqueado);
        }

        public void EliminarProveedorBloqueadoLogico(int idProveedorBloqueado, int idUsuarioModificacion)
        {
            _repository.EliminarProveedorBloqueadoLogico(idProveedorBloqueado, idUsuarioModificacion);
        }

        public void EliminarProveedorBloqueadoFisico(int idProveedorBloqueado)
        {
            _repository.EliminarProveedorBloqueadoFisico(idProveedorBloqueado);
        }
    }
}
