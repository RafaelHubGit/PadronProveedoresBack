using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenDomicilioHistoricoController : ControllerBase
    {
        private readonly GenDomicilioHistoricoService _service;

        public GenDomicilioHistoricoController(GenDomicilioHistoricoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDomiciliosHistorico()
        {
            return Ok(_service.ObtenerDomiciliosHistorico());
        }

        [HttpGet("{idDomicilioHistorico}")]
        public IActionResult GetDomicilioHistoricoPorId(int idDomicilioHistorico)
        {
            return Ok(_service.ObtenerDomicilioHistoricoPorId(idDomicilioHistorico));
        }

        [HttpGet("proveedor/{idProveedorDatos}")]
        public IActionResult GetDomiciliosHistoricoPorProveedorDatos(int idProveedorDatos)
        {
            return Ok(_service.ObtenerDomiciliosHistoricoPorProveedorDatos(idProveedorDatos));
        }

        [HttpPost]
        public IActionResult CrearDomicilioHistorico(GenDomicilioHistoricoModel domicilioHistorico)
        {
            _service.CrearDomicilioHistorico(domicilioHistorico);
            return CreatedAtAction(nameof(GetDomicilioHistoricoPorId), new { idDomicilioHistorico = domicilioHistorico.IdDomicilioHistorico }, domicilioHistorico);
        }

        [HttpPut("{idDomicilioHistorico}")]
        public IActionResult ActualizarDomicilioHistorico(int idDomicilioHistorico, GenDomicilioHistoricoModel domicilioHistorico)
        {
            domicilioHistorico.IdDomicilioHistorico = idDomicilioHistorico;
            _service.ActualizarDomicilioHistorico(domicilioHistorico);
            return NoContent();
        }

        [HttpDelete("{idDomicilioHistorico}")]
        public IActionResult EliminarDomicilioHistorico(int idDomicilioHistorico)
        {
            _service.EliminarDomicilioHistorico(idDomicilioHistorico);
            return NoContent();
        }
    }
}
