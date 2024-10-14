using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class GenProveedorService
    {
        private readonly GenProveedorRepository _repository;

        public GenProveedorService(GenProveedorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GenProveedorModel> ObtenerGenProveedor()
        {
            return _repository.ObtenerGenProveedor();
        }

        public GenProveedorModel ObtenerProveedorPorId(int idProveedor)
        {
            return _repository.ObtenerProveedorPorId(idProveedor);
        }

        public void CrearProveedor(GenProveedorModel proveedor)
        {
            _repository.CrearProveedor(proveedor);
        }

        public void ActualizarProveedor(GenProveedorModel proveedor)
        {
            _repository.ActualizarProveedor(proveedor);
        }

        public void EliminarProveedorLogico(int idProveedor, int idUsuarioModificacion)
        {
            _repository.EliminarProveedorLogico(idProveedor, idUsuarioModificacion);
        }

        public void EliminarProveedorFisico(int idProveedor)
        {
            _repository.EliminarProveedorFisico(idProveedor);
        }
    }
}
