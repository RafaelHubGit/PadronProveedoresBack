using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatTipoDocumentoService
    {
        private readonly GenericRepository _repository;

        public CatTipoDocumentoService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatTipoDocumentoModel> ObtenerTiposDocumentos()
        {
            return _repository.EjecutarStoredProcedureLista<CatTipoDocumentoModel>("EXEC sp_ObtenerCatTipoDocumentos");
        }

        public CatTipoDocumentoModel ObtenerTipoDocumentoPorId(int idTipoDocumento)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoDocumentoModel>(
                "EXEC sp_ObtenerCatTipoDocumentosPorId @IdTipoDocumento = {0}", idTipoDocumento);
        }

        public CatTipoDocumentoModel CrearTipoDocumento(CatTipoDocumentoModel tipoDocumento)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoDocumentoModel>(
                "EXEC sp_CrearCatTipoDocumentos @Nombre = {0}, @Descripcion = {1}, @IdUsuarioAlta = {2}",
                tipoDocumento.Nombre, tipoDocumento.Descripcion, tipoDocumento.IdUsuarioAlta);
        }

        public CatTipoDocumentoModel ActualizarTipoDocumento(CatTipoDocumentoModel tipoDocumento)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoDocumentoModel>(
                "EXEC sp_ActualizarCatTipoDocumentos @IdTipoDocumento = {0}, @Nombre = {1}, @Descripcion = {2}, @IdUsuarioModificacion = {3}, @Activo = {4}",
                tipoDocumento.IdTipoDocumento, tipoDocumento.Nombre, tipoDocumento.Descripcion, tipoDocumento.IdUsuarioModificacion, tipoDocumento.Activo);
        }

        public void EliminarTipoDocumentoLogico(int idTipoDocumento, int idUsuario)
        {
            try
            {
                _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatTipoDocumentosLogico @IdTipoDocumento = {0}, @IdUsuario = {1}", idTipoDocumento, idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public void EliminarTipoDocumentoFisico(int idTipoDocumento)
        {
            _repository.EliminarStoredProcedure("EXEC sp_EliminarCatTipoDocumentosFisico @IdTipoDocumento = {0}", idTipoDocumento);
        }
    }
}
