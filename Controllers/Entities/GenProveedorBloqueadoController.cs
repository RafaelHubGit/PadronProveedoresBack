using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenProveedorBloqueadoController : ControllerBase
    {
        private readonly GenProveedorBloqueadoService _service;

        public GenProveedorBloqueadoController(GenProveedorBloqueadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetProveedoresBloqueados()
        {
            return Ok(_service.ObtenerProveedoresBloqueados());
        }

        [HttpGet("{idProveedorBloqueado}")]
        public IActionResult GetProveedorBloqueadoPorId(int idProveedorBloqueado)
        {
            return Ok(_service.ObtenerProveedorBloqueadoPorId(idProveedorBloqueado));
        }

        [HttpPost]
        public IActionResult CrearProveedorBloqueado(GenProveedorBloqueadoModel proveedorBloqueado)
        {
            _service.CrearProveedorBloqueado(proveedorBloqueado);
            return CreatedAtAction(nameof(GetProveedorBloqueadoPorId), new { idProveedorBloqueado = proveedorBloqueado.IdProveedorBloqueado }, proveedorBloqueado);
        }

        [HttpPut("{idProveedorBloqueado}")]
        public IActionResult ActualizarProveedorBloqueado(int idProveedorBloqueado, GenProveedorBloqueadoModel proveedorBloqueado)
        {
            proveedorBloqueado.IdProveedorBloqueado = idProveedorBloqueado;
            _service.ActualizarProveedorBloqueado(proveedorBloqueado);
            return NoContent();
        }

        [HttpPatch("{idProveedorBloqueado}/estado")]
        public IActionResult EliminarProveedorBloqueadoLogico(int idProveedorBloqueado, int idUsuarioModificacion)
        {
            _service.EliminarProveedorBloqueadoLogico(idProveedorBloqueado, idUsuarioModificacion);
            return NoContent();
        }

        [HttpDelete("{idProveedorBloqueado}")]
        public IActionResult EliminarProveedorBloqueadoFisico(int idProveedorBloqueado)
        {
            _service.EliminarProveedorBloqueadoFisico(idProveedorBloqueado);
            return NoContent();
        }
    }
}
