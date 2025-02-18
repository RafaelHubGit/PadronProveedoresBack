using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatGeneroService
    {
        private readonly GenericRepository _repository;

        public CatGeneroService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatGeneroModel> ObtenerGeneros()
        {
            return _repository.EjecutarStoredProcedureLista<CatGeneroModel>("EXEC sp_ObtenerCatGenero");
        }

        public CatGeneroModel ObtenerGeneroPorId(int idGenero)
        {
            return _repository.EjecutarStoredProcedureUnico<CatGeneroModel>(
                    "EXEC sp_ObtenerCatGeneroPorId @IdGenero = {0}", idGenero);
        }

        public CatGeneroModel CrearGenero(CatGeneroModel genero)
        {
            return _repository.EjecutarStoredProcedureUnico<CatGeneroModel>(
                    "EXEC sp_CrearCatGenero @Genero = {0}, @IdUsuarioAlta = {1}",
                    genero.Genero, genero.IdUsuarioAlta);
        }

        public CatGeneroModel ActualizarGenero(CatGeneroModel genero)
        {
            return _repository.EjecutarStoredProcedureUnico<CatGeneroModel>(
                    "EXEC sp_ActualizarCatGenero @IdGenero = {0}, @Genero = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}",
                    genero.IdGenero, genero.Genero, genero.IdUsuarioModificacion, genero.Activo);
        }

        public void EliminarGeneroLogico(int idGenero, int idUsuario)
        {
            try
            {
                _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatGeneroLogico @IdGenero = {0}, @IdUsuario = {1}", idGenero, idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public void EliminarGeneroFisico(int idGenero)
        {
            _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatGeneroFisico @IdGenero = {0}", idGenero);
        }
    }
}
