using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Models.ConfiguracionReportes;

namespace PadronProveedoresAPI.Services.ConfiguracionReportes
{
    public class GenReporte_FirmantesService
    {
        private readonly GenericRepository _repository;

        public GenReporte_FirmantesService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GenReporte_FirmantesModel> ObtenerFirmantesReporte()
        {
            return _repository.EjecutarStoredProcedureLista<GenReporte_FirmantesModel>("EXEC sp_ObtenerGenReporte_Firmantes");
        }

        public GenReporte_FirmantesModel ObtenerFirmanteReportePorId(int idReporteFirmantes)
        {
            return _repository.EjecutarStoredProcedureUnico<GenReporte_FirmantesModel>("EXEC sp_ObtenerGenReporte_FirmantesPorId @idReporteFirmantes = {0}", idReporteFirmantes);
        }

        public GenReporte_FirmantesModel CrearFirmanteReporte(GenReporte_FirmantesModel firmante)
        {
            return _repository.EjecutarStoredProcedureUnico<GenReporte_FirmantesModel>("EXEC sp_CrearGenReporte_Firmantes @idReportesFirmantes = {0}, @identificadorReporte = {1}, @IdUsuarioAlta = {2}", firmante.IdReportesFirmantes, firmante.IdentificadorReporte, firmante.IdUsuarioAlta);
        }

        public GenReporte_FirmantesModel ActualizarFirmanteReporte(GenReporte_FirmantesModel firmante)
        {
            return _repository.EjecutarStoredProcedureUnico<GenReporte_FirmantesModel>("EXEC sp_ActualizarGenReporte_Firmantes @idReporteFirmantes = {0}, @idReportesFirmantes = {1}, @identificadorReporte = {2}, @IdUsuarioModificacion = {3}, @Activo = {4}", firmante.IdReporteFirmantes, firmante.IdReportesFirmantes, firmante.IdentificadorReporte, firmante.IdUsuarioModificacion, firmante.Activo);
        }

        public void EliminarFirmanteReporteLogico(int idReporteFirmantes, int idUsuario)
        {
            _repository.EjecutarStoredProcedure("EXEC sp_EliminarGenReporte_FirmantesLogico @idReporteFirmantes = {0}, @idUsuario = {1}", idReporteFirmantes, idUsuario);
        }

        public void EliminarFirmanteReporteFisico(int idReporteFirmantes)
        {
            _repository.EliminarStoredProcedure("EXEC sp_EliminarGenReporte_FirmantesFisico @idReporteFirmantes = {0}", idReporteFirmantes);
        }
    }
}
