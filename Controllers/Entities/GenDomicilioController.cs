using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenDomicilioController : ControllerBase
    {
        private readonly GenDomicilioService _service;

        public GenDomicilioController(GenDomicilioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDomicilios()
        {
            return Ok(_service.ObtenerDomicilios());
        }

        [HttpGet("{idDomicilio}")]
        public IActionResult GetDomicilioPorId(int idDomicilio)
        {
            return Ok(_service.ObtenerDomicilioPorId(idDomicilio));
        }

        [HttpPost]
        public IActionResult CrearDomicilio(GenDomicilioModel domicilio)
        {
            _service.CrearDomicilio(domicilio);
            return CreatedAtAction(nameof(GetDomicilioPorId), new { idDomicilio = domicilio.IdDomicilio }, domicilio);
        }

        [HttpPut("{idDomicilio}")]
        public IActionResult ActualizarDomicilio(int idDomicilio, GenDomicilioModel domicilio)
        {
            domicilio.IdDomicilio = idDomicilio;
            _service.ActualizarDomicilio(domicilio);
            return NoContent();
        }

        [HttpPatch("{idDomicilio}/estado")]
        public IActionResult EliminarDomicilioLogico(int idDomicilio, int idUsuarioModificacion)
        {
            _service.EliminarDomicilioLogico(idDomicilio, idUsuarioModificacion);
            return NoContent();
        }

        [HttpDelete("{idDomicilio}")]
        public IActionResult EliminarDomicilioFisico(int idDomicilio)
        {
            _service.EliminarDomicilioFisico(idDomicilio);
            return NoContent();
        }
    }
}
