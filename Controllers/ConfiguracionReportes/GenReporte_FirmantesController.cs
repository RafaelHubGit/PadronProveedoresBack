using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.ConfiguracionReportes;
using PadronProveedoresAPI.Services.ConfiguracionReportes;

namespace PadronProveedoresAPI.Controllers.ConfiguracionReportes
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenReporte_FirmantesController : ControllerBase
    {
        private readonly GenReporte_FirmantesService _service;

        public GenReporte_FirmantesController(GenReporte_FirmantesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetFirmantesReporte()
        {
            return Ok(_service.ObtenerFirmantesReporte());
        }

        [HttpGet("{idReporteFirmantes}")]
        public IActionResult GetFirmanteReportePorId(int idReporteFirmantes)
        {
            return Ok(_service.ObtenerFirmanteReportePorId(idReporteFirmantes));
        }

        [HttpPost]
        public IActionResult CrearFirmanteReporte(GenReporte_FirmantesModel firmante)
        {
            return Ok(_service.CrearFirmanteReporte(firmante));
        }

        [HttpPut("{idReporteFirmantes}")]
        public IActionResult ActualizarFirmanteReporte(int idReporteFirmantes, GenReporte_FirmantesModel firmante)
        {
            firmante.IdReporteFirmantes = idReporteFirmantes;
            return Ok(_service.ActualizarFirmanteReporte(firmante));
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarFirmanteReporteLogico(int idReporteFirmantes, int idUsuario)
        {
            _service.EliminarFirmanteReporteLogico(idReporteFirmantes, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idReporteFirmantes}")]
        public IActionResult EliminarFirmanteReporteFisico(int idReporteFirmantes)
        {
            try
            {
                _service.EliminarFirmanteReporteFisico(idReporteFirmantes);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error interno.", details = ex.Message });
            }
        }
    }
}
