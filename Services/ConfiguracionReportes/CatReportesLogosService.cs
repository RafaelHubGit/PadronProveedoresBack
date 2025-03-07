using PadronProveedoresAPI.Data.Repository;
using PadronProveedoresAPI.MiddleWare.Logs;
using PadronProveedoresAPI.Models.ConfiguracionReportes;
using PadronProveedoresAPI.Utilities;
using System.Transactions;
using static PadronProveedoresAPI.Utilities.Utilidades;
using static System.Net.Mime.MediaTypeNames;

namespace PadronProveedoresAPI.Services.ConfiguracionReportes
{
    public class CatReportesLogosService
    {
        private readonly GenericRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly string _carpetaLogoReportes;
        private readonly CustomLogger _logger;



        public CatReportesLogosService(
            GenericRepository repository,
            IConfiguration configuration,
            CustomLogger logger
        )
        {
            _repository = repository;
            _configuration = configuration;
            _carpetaLogoReportes = _configuration["CarpetasDocumentos:LogoReportes"];
            _logger = logger;
        }

        public IEnumerable<CatReportesLogosModel> ObtenerLogos()
        {
            return _repository.EjecutarStoredProcedureLista<CatReportesLogosModel>("EXEC sp_ObtenerCatReportesLogos");
        }

        public CatReportesLogosModel ObtenerLogoPorId(int idReportesLogos)
        {
            return _repository.EjecutarStoredProcedureUnico<CatReportesLogosModel>("EXEC sp_ObtenerCatReportesLogosPorId @idReportesLogos = {0}", idReportesLogos);
        }

        public byte[] ObtenerLogoImagen(string nombreImagen)
        {
            try
            {
                var archivoUtilidades = new Utilidades.ArchivoUtilidades();
                var carpeta = _carpetaLogoReportes;
                return archivoUtilidades.RecuperarArchivo(carpeta, nombreImagen);
            }
            catch (FileNotFoundException ex)
            {
                // Registra el error y devuelve null
                _logger.LogError(ex, $"Archivo no encontrado: {nombreImagen}");
                return null;
            }
            catch (Exception ex)
            {
                // Registra el error y devuelve null
                _logger.LogError(ex, $"Error al obtener archivo: {nombreImagen}");
                return null;
            }
        }

        //public CatReportesLogosModel CrearLogo(CatReportesLogosModel logo, IFormFile imagen)
        //{
        //    var archivoUtilidades = new Utilidades.ArchivoUtilidades();
        //    var resul = archivoUtilidades.GuardarArchivo( imagen, "ReportesLogos" );
        //    return _repository.EjecutarStoredProcedureUnico<CatReportesLogosModel>("EXEC sp_CrearCatReportesLogos @nombre = {0}, @descripcion = {1}, @IdUsuarioAlta = {2}", logo.Nombre, logo.Descripcion, logo.IdUsuarioAlta);
        //}
        public CatReportesLogosModel CrearLogo(CatReportesLogosModel logo, IFormFile imagen)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                var archivoUtilidades = new Utilidades.ArchivoUtilidades();
                ArchivoUtilidades.ArchivoResultado resultadoArchivo = null;

                var carpeta = _carpetaLogoReportes;

                try
                {

                    // Intentar guardar el archivo
                    resultadoArchivo = archivoUtilidades.GuardarArchivo(imagen, carpeta);
                    archivoUtilidades.GenerarMiniatura( carpeta,
                                                        carpeta,
                                                        resultadoArchivo.NombreArchivo, 
                                                        $"thumb_{resultadoArchivo.NombreArchivo}",
                                                        150, 150);

                    // Intentar guardar en la base de datos
                    var resultadoBD = _repository.EjecutarStoredProcedureUnico<CatReportesLogosModel>
                        ("EXEC sp_CrearCatReportesLogos @nombre = {0}, @descripcion = {1}, @IdUsuarioAlta = {2}",
                        resultadoArchivo.NombreArchivo, logo.Descripcion, logo.IdUsuarioAlta);


                    // Si todo fue exitoso, confirmar la transacción
                    transaction.Complete();

                    return resultadoBD;
                }
                catch (Exception ex)
                {
                    // Si algo falla, se elimina el archivo
                    archivoUtilidades.EliminaArchivo(carpeta, resultadoArchivo.NombreArchivo);
                    archivoUtilidades.EliminaArchivo(carpeta, $"thumb_{ resultadoArchivo.NombreArchivo}");

                    throw new Exception("Error al guardar el logo", ex);
                }
            }
        }

        public CatReportesLogosModel ActualizarLogo(CatReportesLogosModel logo)
        {
            return _repository.EjecutarStoredProcedureUnico<CatReportesLogosModel>("EXEC sp_ActualizarCatReportesLogos @idReportesLogos = {0}, @nombre = {1}, @descripcion = {2}, @IdUsuarioModificacion = {3}, @Activo = {4}", logo.IdReportesLogos, logo.Nombre, logo.Descripcion, logo.IdUsuarioModificacion, logo.Activo);
        }

        public void EliminarLogoLogico(int idReportesLogos, int idUsuario)
        {
            _repository.EjecutarStoredProcedure("EXEC sp_EliminarCatReportesLogosLogico @idReportesLogos = {0}, @idUsuario = {1}", idReportesLogos, idUsuario);
        }

        public void EliminarLogoFisico(int idReporteFirmantes)
        {
            _repository.EliminarStoredProcedure("EXEC sp_EliminarCatReportesLogosFisico @idReporteFirmantes = {0}", idReporteFirmantes);
        }
    }
}
