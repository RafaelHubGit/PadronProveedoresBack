using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatEstatusProveedorBloqueadoService
    {
        //private readonly CatEstatusProveedorBloqueadoRepository _repository;
        private readonly GenericRepository _repository;

        public CatEstatusProveedorBloqueadoService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatEstatusProveedorBloqueadoModel> ObtenerEstatusProveedoresBloqueados()
        {
            return _repository.EjecutarStoredProcedureLista<CatEstatusProveedorBloqueadoModel>("EXEC sp_ObtenerCatEstatusProveedorBloqueado");
        }

        public CatEstatusProveedorBloqueadoModel ObtenerEstatusProveedorBloqueadoPorId(int idEstatusProveedorBloqueado)
        {
            return _repository.EjecutarStoredProcedureUnico<CatEstatusProveedorBloqueadoModel>(
                    "EXEC sp_ObtenerCatEstatusProveedorBloqueadoPorId @IdEstatusProveedorBloqueado = {0}", idEstatusProveedorBloqueado);
        }

        public CatEstatusProveedorBloqueadoModel CrearEstatusProveedorBloqueado(CatEstatusProveedorBloqueadoModel estatusProveedorBloqueado)
        {
            return _repository.EjecutarStoredProcedureUnico<CatEstatusProveedorBloqueadoModel>(
                    "EXEC sp_CrearCatEstatusProveedorBloqueado @Estatus = {0}, @IdUsuarioAlta = {1}",
                    estatusProveedorBloqueado.Estatus, estatusProveedorBloqueado.IdUsuarioAlta);
        }

        public CatEstatusProveedorBloqueadoModel ActualizarEstatusProveedorBloqueado(CatEstatusProveedorBloqueadoModel estatusProveedorBloqueado)
        {
            return _repository.EjecutarStoredProcedureUnico<CatEstatusProveedorBloqueadoModel>(
                    "EXEC sp_ActualizarCatEstatusProveedorBloqueado @IdEstatusProveedorBloqueado = {0}, @Estatus = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}",
                    estatusProveedorBloqueado.IdEstatusProveedorBloqueado, estatusProveedorBloqueado.Estatus, estatusProveedorBloqueado.IdUsuarioModificacion, estatusProveedorBloqueado.Activo);
        }

        public void EliminarEstatusProveedorBloqueadoLogico(int idEstatusProveedorBloqueado, int idUsuario)
        {
            try
            {
                _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatEstatusProveedorBloqueadoLogico @IdEstatusProveedorBloqueado = {0}, @IdUsuario = {1}", idEstatusProveedorBloqueado, idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public void EliminarEstatusProveedorBloqueadoFisico(int idEstatusProveedorBloqueado)
        {
            _repository.EliminarStoredProcedure("EXEC sp_EliminarCatEstatusProveedorBloqueadoFisico @IdEstatusProveedorBloqueado = {0}", idEstatusProveedorBloqueado);
        }
    }
}
