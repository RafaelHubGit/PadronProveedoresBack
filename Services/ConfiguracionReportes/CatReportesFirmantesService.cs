using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Models.ConfiguracionReportes;

namespace PadronProveedoresAPI.Services.ConfiguracionReportes
{
    public class CatReportesFirmantesService
    {
        private readonly GenericRepository _repository;

        public CatReportesFirmantesService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatReportesFirmantesModel> ObtenerFirmantes()
        {
            return _repository.EjecutarStoredProcedureLista<CatReportesFirmantesModel>("EXEC sp_ObtenerCatReportesFirmantes");
        }

        public CatReportesFirmantesModel ObtenerFirmantePorId(int idReportesFirmantes)
        {
            return _repository.EjecutarStoredProcedureUnico<CatReportesFirmantesModel>("EXEC sp_ObtenerCatReportesFirmantesPorId @idReportesFirmantes = {0}", idReportesFirmantes);
        }

        public CatReportesFirmantesModel CrearFirmante(CatReportesFirmantesModel firmante)
        {
            return _repository.EjecutarStoredProcedureUnico<CatReportesFirmantesModel>("EXEC sp_CrearCatReportesFirmantes @nombre = {0}, @cargo = {1}, @prefijo = {2}, @IdUsuarioAlta = {3}", firmante.Nombre, firmante.Cargo, firmante.Prefijo, firmante.IdUsuarioAlta);
        }

        public CatReportesFirmantesModel ActualizarFirmante(CatReportesFirmantesModel firmante)
        {
            return _repository.EjecutarStoredProcedureUnico<CatReportesFirmantesModel>("EXEC sp_ActualizarCatReportesFirmantes @idReportesFirmantes = {0}, @nombre = {1}, @cargo = {2}, @prefijo = {3}, @IdUsuarioModificacion = {4}, @Activo = {5}", firmante.IdReportesFirmantes, firmante.Nombre, firmante.Cargo, firmante.Prefijo, firmante.IdUsuarioModificacion, firmante.Activo);
        }

        public void EliminarFirmanteLogico(int idReportesFirmantes, int idUsuario)
        {
            _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatReportesFirmantesLogico @idReportesFirmantes = {0}, @idUsuario = {1}", idReportesFirmantes, idUsuario);
        }

        public void EliminarFirmanteFisico(int idReportesFirmantes)
        {
            _repository.EliminarStoredProcedure("EXEC sp_EliminarCatReportesFirmantesFisico @idReportesFirmantes = {0}", idReportesFirmantes);
        }
    }
}
