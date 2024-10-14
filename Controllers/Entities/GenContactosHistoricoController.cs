using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenContactosHistoricoController : ControllerBase
    {
        private readonly GenContactosHistoricoService _service;

        public GenContactosHistoricoController(GenContactosHistoricoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetContactosHistorico()
        {
            return Ok(_service.ObtenerContactosHistorico());
        }

        [HttpGet("{idContactoHistorico}")]
        public IActionResult GetContactoHistoricoPorId(int idContactoHistorico)
        {
            return Ok(_service.ObtenerContactoHistoricoPorId(idContactoHistorico));
        }

        [HttpGet("proveedor/{idProveedorDatos}")]
        public IActionResult GetContactosHistoricoPorProveedorDatos(int idProveedorDatos)
        {
            return Ok(_service.ObtenerContactosHistoricoPorProveedorDatos(idProveedorDatos));
        }

        [HttpPost]
        public IActionResult CrearContactoHistorico(GenContactosHistoricoModel contactoHistorico)
        {
            _service.CrearContactoHistorico(contactoHistorico);
            return CreatedAtAction(nameof(GetContactoHistoricoPorId), new { idContactoHistorico = contactoHistorico.IdContactoHistorico }, contactoHistorico);
        }

        [HttpPut("{idContactoHistorico}")]
        public IActionResult ActualizarContactoHistorico(int idContactoHistorico, GenContactosHistoricoModel contactoHistorico)
        {
            contactoHistorico.IdContactoHistorico = idContactoHistorico;
            _service.ActualizarContactoHistorico(contactoHistorico);
            return NoContent();
        }

        [HttpDelete("{idContactoHistorico}")]
        public IActionResult EliminarContactoHistorico(int idContactoHistorico)
        {
            _service.EliminarContactoHistorico(idContactoHistorico);
            return NoContent();
        }
    }
}
