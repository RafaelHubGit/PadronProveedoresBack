using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.ConfiguracionReportes;
using PadronProveedoresAPI.Services.ConfiguracionReportes;

namespace PadronProveedoresAPI.Controllers.ConfiguracionReportes
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatReportesFirmantesController : ControllerBase
    {
        private readonly CatReportesFirmantesService _service;

        public CatReportesFirmantesController(CatReportesFirmantesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetFirmantes()
        {
            return Ok(_service.ObtenerFirmantes());
        }

        [HttpGet("{idReportesFirmantes}")]
        public IActionResult GetFirmantePorId(int idReportesFirmantes)
        {
            return Ok(_service.ObtenerFirmantePorId(idReportesFirmantes));
        }

        [HttpPost]
        public IActionResult CrearFirmante(CatReportesFirmantesModel firmante)
        {
            return Ok(_service.CrearFirmante(firmante));
        }

        [HttpPut("{idReportesFirmantes}")]
        public IActionResult ActualizarFirmante(int idReportesFirmantes, CatReportesFirmantesModel firmante)
        {
            firmante.IdReportesFirmantes = idReportesFirmantes;
            return Ok(_service.ActualizarFirmante(firmante));
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarFirmanteLogico(int idReportesFirmantes, int idUsuario)
        {
            _service.EliminarFirmanteLogico(idReportesFirmantes, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idReportesFirmantes}")]
        public IActionResult EliminarFirmanteFisico(int idReportesFirmantes)
        {
            try
            {
                _service.EliminarFirmanteFisico(idReportesFirmantes);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error interno.", details = ex.Message });
            }
        }
    }
}
