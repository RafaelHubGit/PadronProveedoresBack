using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.Models.ConfiguracionReportes;

namespace PadronProveedoresAPI.Services.ConfiguracionReportes
{
    public class CatReportesLeyendasService
    {
        private readonly GenericRepository _repository;

        public CatReportesLeyendasService(GenericRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatReportesLeyendasModel> ObtenerLeyendas()
        {
            return _repository.EjecutarStoredProcedureLista<CatReportesLeyendasModel>("EXEC sp_ObtenerCatReportesLeyendas");
        }

        public CatReportesLeyendasModel ObtenerLeyendaPorId(int idReportesLeyendas)
        {
            return _repository.EjecutarStoredProcedureUnico<CatReportesLeyendasModel>("EXEC sp_ObtenerCatReportesLeyendasPorId @idReportesLeyendas = {0}", idReportesLeyendas);
        }

        public CatReportesLeyendasModel CrearLeyenda(CatReportesLeyendasModel leyenda)
        {
            return _repository.EjecutarStoredProcedureUnico<CatReportesLeyendasModel>("EXEC sp_CrearCatReportesLeyendas @leyenda = {0}, @IdUsuarioAlta = {1}", leyenda.Leyenda, leyenda.IdUsuarioAlta);
        }

        public CatReportesLeyendasModel ActualizarLeyenda(CatReportesLeyendasModel leyenda)
        {
            return _repository.EjecutarStoredProcedureUnico<CatReportesLeyendasModel>("EXEC sp_ActualizarCatReportesLeyendas @idReportesLeyendas = {0}, @leyenda = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}", leyenda.IdReportesLeyendas, leyenda.Leyenda, leyenda.IdUsuarioModificacion, leyenda.Activo);
        }

        public void EliminarLeyendaLogico(int idReportesLeyendas, int idUsuario)
        {
            _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatReportesLeyendasLogico @idReportesLeyendas = {0}, @idUsuario = {1}", idReportesLeyendas, idUsuario);
        }

        public void EliminarLeyendaFisico(int idReportesLeyendas)
        {
            _repository.EliminarStoredProcedure("EXEC sp_EliminarCatReportesLeyendasFisico @idReportesLeyendas = {0}", idReportesLeyendas);
        }
    }
}
