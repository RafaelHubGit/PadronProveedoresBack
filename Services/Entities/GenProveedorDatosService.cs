using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class GenProveedorDatosService
    {
        private readonly GenProveedorDatosRepository _repository;

        public GenProveedorDatosService(GenProveedorDatosRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GenProveedorDatosModel> ObtenerProveedorDatos()
        {
            return _repository.ObtenerProveedorDatos();
        }

        public GenProveedorDatosModel ObtenerProveedorDatosPorId(int idProveedorDatos)
        {
            return _repository.ObtenerProveedorDatosPorId(idProveedorDatos);
        }

        public void CrearProveedorDatos(GenProveedorDatosModel proveedorDatos)
        {
            _repository.CrearProveedorDatos(proveedorDatos);
        }

        public void ActualizarProveedorDatos(GenProveedorDatosModel proveedorDatos)
        {
            _repository.ActualizarProveedorDatos(proveedorDatos);
        }

        public void EliminarProveedorDatosLogico(int idProveedorDatos, int idUsuarioModificacion)
        {
            _repository.EliminarProveedorDatosLogico(idProveedorDatos, idUsuarioModificacion);
        }

        public void EliminarProveedorDatosFisico(int idProveedorDatos)
        {
            _repository.EliminarProveedorDatosFisico(idProveedorDatos);
        }
    }
}
