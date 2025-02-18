using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatTipoProveedorService
    {
        private readonly GenericRepository _repository;

        public CatTipoProveedorService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatTipoProveedorModel> ObtenerTiposProveedor()
        {
            return _repository.EjecutarStoredProcedureLista<CatTipoProveedorModel>("EXEC sp_ObtenerCatTipoProveedor");
        }

        public CatTipoProveedorModel ObtenerTipoProveedorPorId(int idTipoProveedor)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoProveedorModel>(
                "EXEC sp_ObtenerTipoProveedorPorId @IdTipoProveedor = {0}", idTipoProveedor);
        }

        public CatTipoProveedorModel CrearTipoProveedor(CatTipoProveedorModel tipoProveedor)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoProveedorModel>(
                "EXEC sp_CrearCatTipoProveedor @TipoProveedor = {0}, @IdUsuarioAlta = {1}",
                tipoProveedor.TipoProveedor, tipoProveedor.IdUsuarioAlta);
        }

        public CatTipoProveedorModel ActualizarTipoProveedor(CatTipoProveedorModel tipoProveedor)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoProveedorModel>(
                "EXEC sp_ActualizarCatTipoProveedor @IdTipoProveedor = {0}, @TipoProveedor = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}",
                tipoProveedor.IdTipoProveedor, tipoProveedor.TipoProveedor, tipoProveedor.IdUsuarioModificacion, tipoProveedor.Activo);
        }

        public void EliminarTipoProveedorLogico(int idTipoProveedor, int idUsuario)
        {
            try
            {
                _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatTipoProveedorLogico @IdTipoProveedor = {0}, @IdUsuario = {1}", idTipoProveedor, idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public void EliminarTipoProveedorFisico(int idTipoProveedor)
        {
            _repository.EliminarStoredProcedure("EXEC sp_EliminarCatTipoProveedorFisico @IdTipoProveedor = {0}", idTipoProveedor);
        }
    }
}
