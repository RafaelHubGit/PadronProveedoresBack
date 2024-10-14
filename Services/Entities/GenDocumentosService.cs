using PadronProveedoresAPI.Data.Repository.Entities;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class GenDocumentosService
    {
        private readonly GenDocumentosRepository _repository;

        public GenDocumentosService(GenDocumentosRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GenDocumentosModel> ObtenerDocumentos()
        {
            return _repository.ObtenerDocumentos();
        }

        public GenDocumentosModel ObtenerDocumentoPorId(int idDocumentos)
        {
            return _repository.ObtenerDocumentoPorId(idDocumentos);
        }

        public IEnumerable<GenDocumentosModel> ObtenerDocumentosPorProveedorDatos(int idProveedorDatos)
        {
            return _repository.ObtenerDocumentosPorProveedorDatos(idProveedorDatos);
        }

        public void CrearDocumento(GenDocumentosModel documento)
        {
            _repository.CrearDocumento(documento);
        }

        public void ActualizarDocumento(GenDocumentosModel documento)
        {
            _repository.ActualizarDocumento(documento);
        }

        public void EliminarDocumentoLogico(int idDocumentos, int idUsuarioModificacion)
        {
            _repository.EliminarDocumentoLogico(idDocumentos, idUsuarioModificacion);
        }

        public void EliminarDocumentoFisico(int idDocumentos)
        {
            _repository.EliminarDocumentoFisico(idDocumentos);
        }
    }
}
