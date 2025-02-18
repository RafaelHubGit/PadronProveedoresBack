using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatTipoContactoService
    {

        private readonly GenericRepository _repository;

        public CatTipoContactoService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatTipoContactoModel> ObtenerTiposContacto()
        {
            return _repository.EjecutarStoredProcedureLista<CatTipoContactoModel>("EXEC sp_ObtenerCatTipoContacto");
        }

        public CatTipoContactoModel ObtenerTipoContactoPorId(int idTipoContacto)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoContactoModel>(
                "EXEC sp_ObtenerCatTipoContactoPorId @IdTipoContacto = {0}", idTipoContacto);
        }

        public CatTipoContactoModel CrearTipoContacto(CatTipoContactoModel tipoContacto)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoContactoModel>(
                "EXEC sp_CrearCatTipoContacto @TipoContacto = {0}, @IdUsuarioAlta = {1}",
                tipoContacto.TipoContacto, tipoContacto.IdUsuarioAlta);
        }

        public CatTipoContactoModel ActualizarTipoContacto(CatTipoContactoModel tipoContacto)
        {
            return _repository.EjecutarStoredProcedureUnico<CatTipoContactoModel>(
                "EXEC sp_ActualizarCatTipoContacto @IdTipoContacto = {0}, @TipoContacto = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}",
                tipoContacto.IdTipoContacto, tipoContacto.TipoContacto, tipoContacto.IdUsuarioModificacion, tipoContacto.Activo);
        }

        public void EliminarTipoContactoLogico(int idTipoContacto, int idUsuario)
        {
            try
            {
                _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatTipoContactoLogico @IdTipoContacto = {0}, @IdUsuario = {1}", idTipoContacto, idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public void EliminarTipoContactoFisico(int idTipoContacto)
        {
            _repository.EliminarStoredProcedure("EXEC sp_EliminarCatTipoContactoFisico @IdTipoContacto = {0}", idTipoContacto);
        }

    }
}
