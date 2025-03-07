using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.ConfiguracionReportes;
using PadronProveedoresAPI.Services.ConfiguracionReportes;

namespace PadronProveedoresAPI.Controllers.ConfiguracionReportes
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatReportesLogosController : ControllerBase
    {
        private readonly CatReportesLogosService _service;

        public CatReportesLogosController(CatReportesLogosService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetLogos()
        {
            return Ok(_service.ObtenerLogos());
        }

        [HttpGet("{idReportesLogos}")]
        public IActionResult GetLogoPorId(int idReportesLogos)
        {
            return Ok(_service.ObtenerLogoPorId(idReportesLogos));
        }

        [HttpGet("imagen/{nombreImagen}")]
        public IActionResult GetLogo(string nombreImagen)
        {
            var bytes = _service.ObtenerLogoImagen(nombreImagen);
            if (bytes != null)
            {
                return File(bytes, "image/png");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Consumes("multipart/form-data")] // Indica que el endpoint recibe multipart/form-data

        public IActionResult CrearLogo([FromForm] CatReportesLogosModel logo, [FromForm] IFormFile imagen)
        {
            return Ok(_service.CrearLogo(logo, imagen));
        }

        [HttpPut("{idReportesLogos}")]
        public IActionResult ActualizarLogo(int idReportesLogos, CatReportesLogosModel logo)
        {
            logo.IdReportesLogos = idReportesLogos;
            return Ok(_service.ActualizarLogo(logo));
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarLogoLogico(int idReportesLogos, int idUsuario)
        {
            _service.EliminarLogoLogico(idReportesLogos, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idReportesLogos}")]
        public IActionResult EliminarLogoFisico(int idReportesLogos)
        {
            try
            {
                _service.EliminarLogoFisico(idReportesLogos);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error interno.", details = ex.Message });
            }
        }
    }
}
