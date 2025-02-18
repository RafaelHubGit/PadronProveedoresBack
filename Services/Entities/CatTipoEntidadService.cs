using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatTipoEntidadService
    {
        private readonly GenericRepository _repository;

        public CatTipoEntidadService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatTipoEntidadModel> ObtenerTiposEntidad()
        {
            return _repository.EjecutarStoredProcedureLista<CatTipoEntidadModel>("EXEC sp_ObtenerCatTipoEntidad");
        }

        public CatTipoEntidadModel ObtenerTipoEntidadPorId(int idTipoEntidad)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoEntidadModel>(
                "EXEC sp_ObtenerTipoEntidadPorId @IdTipoEntidad = {0}", idTipoEntidad);
        }

        public CatTipoEntidadModel CrearTipoEntidad(CatTipoEntidadModel tipoEntidad)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoEntidadModel>(
                "EXEC sp_CrearCatTipoEntidad @TipoEntidad = {0}, @IdUsuarioAlta = {1}",
                tipoEntidad.TipoEntidad, tipoEntidad.IdUsuarioAlta);
        }

        public CatTipoEntidadModel ActualizarTipoEntidad(CatTipoEntidadModel tipoEntidad)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoEntidadModel>(
                "EXEC sp_ActualizarCatTipoEntidad @IdTipoEntidad = {0}, @TipoEntidad = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}",
                tipoEntidad.IdTipoEntidad, tipoEntidad.TipoEntidad, tipoEntidad.IdUsuarioModificacion, tipoEntidad.Activo);
        }

        public void EliminarTipoEntidadLogico(int idTipoEntidad, int idUsuario)
        {
            try
            {
                _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatTipoEntidadLogico @IdTipoEntidad = {0}, @IdUsuario = {1}", idTipoEntidad, idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public void EliminarTipoEntidadFisico(int idTipoEntidad)
        {
            _repository.EliminarStoredProcedure("EXEC sp_EliminarCatTipoEntidadFisico @IdTipoEntidad = {0}", idTipoEntidad);
        }
    }
}
