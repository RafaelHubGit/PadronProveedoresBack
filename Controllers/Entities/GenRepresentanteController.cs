using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenRepresentanteController : ControllerBase
    {
        private readonly GenRepresentanteService _service;

        public GenRepresentanteController(GenRepresentanteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetRepresentantes()
        {
            return Ok(_service.ObtenerRepresentantes());
        }

        [HttpGet("{idRepresentante}")]
        public IActionResult GetRepresentantePorId(int idRepresentante)
        {
            return Ok(_service.ObtenerRepresentantePorId(idRepresentante));
        }

        [HttpPost]
        public IActionResult CrearRepresentante(GenRepresentanteModel representante)
        {
            _service.CrearRepresentante(representante);
            return CreatedAtAction(nameof(GetRepresentantePorId), new { idRepresentante = representante.IdRepresentante }, representante);
        }

        [HttpPut("{idRepresentante}")]
        public IActionResult ActualizarRepresentante(int idRepresentante, GenRepresentanteModel representante)
        {
            representante.IdRepresentante = idRepresentante;
            _service.ActualizarRepresentante(representante);
            return NoContent();
        }

        [HttpPatch("{idRepresentante}/estado")]
        public IActionResult EliminarRepresentanteLogico(int idRepresentante, int idUsuarioModificacion)
        {
            _service.EliminarRepresentanteLogico(idRepresentante, idUsuarioModificacion);
            return NoContent();
        }

        [HttpDelete("{idRepresentante}")]
        public IActionResult EliminarRepresentanteFisico(int idRepresentante)
        {
            _service.EliminarRepresentanteFisico(idRepresentante);
            return NoContent();
        }
    }
}
