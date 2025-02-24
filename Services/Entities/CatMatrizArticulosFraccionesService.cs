using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Services.Entities
{
    public class CatMatrizArticulosFraccionesService
    {
        private readonly GenericRepository _repository;

        public CatMatrizArticulosFraccionesService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatMatrizArticulosFraccionesModel> ObtenerMatrizArticulosFracciones()
        {
            return _repository.EjecutarStoredProcedureLista<CatMatrizArticulosFraccionesModel>("EXEC sp_ObtenerCatMatrizArticulosFracciones");
        }

        public CatMatrizArticulosFraccionesModel ObtenerMatrizArticulosFraccionesPorId(int idMatrizArticulosFracciones)
        {
            return _repository.EjecutarStoredProcedureUnico<CatMatrizArticulosFraccionesModel>(
                    "EXEC sp_ObtenerCatMatrizArticulosFraccionesPorId @IdMatrizArticulosFracciones = {0}", idMatrizArticulosFracciones);
        }

        public CatMatrizArticulosFraccionesModel CrearMatrizArticulosFracciones(CatMatrizArticulosFraccionesModel matrizArticulosFracciones)
        {
            return _repository.EjecutarStoredProcedureUnico<CatMatrizArticulosFraccionesModel>(
                    "EXEC sp_CrearCatMatrizArticulosFracciones @Articulo = {0}, @Fraccion = {1}, @Descripcion = {2}, @Nota = {3}, @IdUsuarioAlta = {4}",
                    matrizArticulosFracciones.Articulo, matrizArticulosFracciones.Fraccion, matrizArticulosFracciones.Descripcion, matrizArticulosFracciones.Nota, matrizArticulosFracciones.IdUsuarioAlta);
        }

        public CatMatrizArticulosFraccionesModel ActualizarMatrizArticulosFracciones(CatMatrizArticulosFraccionesModel matrizArticulosFracciones)
        {
            return _repository.EjecutarStoredProcedureUnico<CatMatrizArticulosFraccionesModel>(
                    "EXEC sp_ActualizarCatMatrizArticulosFracciones @IdMatrizArticulosFracciones = {0}, @Articulo = {1}, @Fraccion = {2}, @Descripcion = {3}, @Nota = {4}, @IdUsuarioModificacion = {5}, @Activo = {6}",
                    matrizArticulosFracciones.IdMatrizArticulosFracciones, matrizArticulosFracciones.Articulo, matrizArticulosFracciones.Fraccion, matrizArticulosFracciones.Descripcion, matrizArticulosFracciones.Nota, matrizArticulosFracciones.IdUsuarioModificacion, matrizArticulosFracciones.Activo);
        }

        public void EliminarMatrizArticulosFraccionesLogico(int idMatrizArticulosFracciones, int idUsuario)
        {
            try
            {
                _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatMatrizArticulosFraccionesLogico @IdMatrizArticulosFracciones = {0}, @IdUsuario = {1}", idMatrizArticulosFracciones, idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public void EliminarMatrizArticulosFraccionesFisico(int idMatrizArticulosFracciones)
        {
            _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatMatrizArticulosFraccionesFisico @IdMatrizArticulosFracciones = {0}", idMatrizArticulosFracciones);
        }
    }
}
