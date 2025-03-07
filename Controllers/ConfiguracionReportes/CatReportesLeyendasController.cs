using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.ConfiguracionReportes;
using PadronProveedoresAPI.Services.ConfiguracionReportes;

namespace PadronProveedoresAPI.Controllers.ConfiguracionReportes
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatReportesLeyendasController : ControllerBase
    {
        private readonly CatReportesLeyendasService _service;

        public CatReportesLeyendasController(CatReportesLeyendasService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetLeyendas()
        {
            return Ok(_service.ObtenerLeyendas());
        }

        [HttpGet("{idReportesLeyendas}")]
        public IActionResult GetLeyendaPorId(int idReportesLeyendas)
        {
            return Ok(_service.ObtenerLeyendaPorId(idReportesLeyendas));
        }

        [HttpPost]
        public IActionResult CrearLeyenda(CatReportesLeyendasModel leyenda)
        {
            return Ok(_service.CrearLeyenda(leyenda));
        }

        [HttpPut("{idReportesLeyendas}")]
        public IActionResult ActualizarLeyenda(int idReportesLeyendas, CatReportesLeyendasModel leyenda)
        {
            leyenda.IdReportesLeyendas = idReportesLeyendas;
            return Ok(_service.ActualizarLeyenda(leyenda));
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarLeyendaLogico(int idReportesLeyendas, int idUsuario)
        {
            _service.EliminarLeyendaLogico(idReportesLeyendas, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idReportesLeyendas}")]
        public IActionResult EliminarLeyendaFisico(int idReportesLeyendas)
        {
            try
            {
                _service.EliminarLeyendaFisico(idReportesLeyendas);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error interno.", details = ex.Message });
            }
        }
    }
}
