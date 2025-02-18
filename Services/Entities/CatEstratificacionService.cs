using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatEstratificacionService
    {
        private readonly GenericRepository _repository;

        public CatEstratificacionService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatEstratificacionModel> ObtenerEstratificaciones()
        {
            return _repository.EjecutarStoredProcedureLista<CatEstratificacionModel>("EXEC sp_ObtenerCatEstratificacion");
        }

        public CatEstratificacionModel ObtenerEstratificacionPorId(int idEstratificacion)
        {
            return _repository.EjecutarStoredProcedureUnico<CatEstratificacionModel>(
                    "EXEC sp_ObtenerCatEstratificacionPorId @IdEstratificacion = {0}", idEstratificacion);
        }

        public CatEstratificacionModel CrearEstratificacion(CatEstratificacionModel estratificacion)
        {
            return _repository.EjecutarStoredProcedureUnico<CatEstratificacionModel>(
                    "EXEC sp_CrearCatEstratificacion @Estratificacion = {0}, @IdUsuarioAlta = {1}",
                    estratificacion.Estratificacion, estratificacion.IdUsuarioAlta);
        }

        public CatEstratificacionModel ActualizarEstratificacion(CatEstratificacionModel estratificacion)
        {
            return _repository.EjecutarStoredProcedureUnico<CatEstratificacionModel>(
                    "EXEC sp_ActualizarCatEstratificacion @IdEstratificacion = {0}, @Estratificacion = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}",
                    estratificacion.IdEstratificacion, estratificacion.Estratificacion, estratificacion.IdUsuarioModificacion, estratificacion.Activo);
        }

        public void EliminarEstratificacionLogico(int idEstratificacion, int idUsuario)
        {
            try
            {
                _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatEstratificacionLogico @IdEstratificacion = {0}, @IdUsuario = {1}", idEstratificacion, idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public void EliminarEstratificacionFisico(int idEstratificacion)
        {
            _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatEstratificacionFisico @IdEstratificacion = {0}", idEstratificacion);
        }
    }
}
