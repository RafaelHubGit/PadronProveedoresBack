using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenContactoController : ControllerBase
    {
        private readonly GenContactoService _service;

        public GenContactoController(GenContactoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetContactos()
        {
            return Ok(_service.ObtenerContactos());
        }

        [HttpGet("{idContacto}")]
        public IActionResult GetContactoPorId(int idContacto)
        {
            return Ok(_service.ObtenerContactoPorId(idContacto));
        }

        [HttpPost]
        public IActionResult CrearContacto(GenContactoModel contacto)
        {
            _service.CrearContacto(contacto);
            return CreatedAtAction(nameof(GetContactoPorId), new { idContacto = contacto.IdContacto }, contacto);
        }

        [HttpPut("{idContacto}")]
        public IActionResult ActualizarContacto(int idContacto, GenContactoModel contacto)
        {
            contacto.IdContacto = idContacto;
            _service.ActualizarContacto(contacto);
            return NoContent();
        }

        [HttpPatch("{idContacto}/estado")]
        public IActionResult EliminarContactoLogico(int idContacto, int idUsuarioModificacion)
        {
            _service.EliminarContactoLogico(idContacto, idUsuarioModificacion);
            return NoContent();
        }

        [HttpDelete("{idContacto}")]
        public IActionResult EliminarContactoFisico(int idContacto)
        {
            _service.EliminarContactoFisico(idContacto);
            return NoContent();
        }
    }
}
