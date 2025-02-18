using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatTipoContactoController : ControllerBase
    {
        private readonly CatTipoContactoService _service;

        public CatTipoContactoController(CatTipoContactoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTiposContacto()
        {
            return Ok(_service.ObtenerTiposContacto());
        }

        [HttpGet("{idTipoContacto}")]
        public IActionResult GetTipoContactoPorId(int idTipoContacto)
        {
            return Ok(_service.ObtenerTipoContactoPorId(idTipoContacto));
        }

        [HttpPost]
        public IActionResult CrearTipoContacto(CatTipoContactoModel tipoContacto)
        {
            return Ok(_service.CrearTipoContacto(tipoContacto));
        }

        [HttpPut("{idTipoContacto}")]
        public IActionResult ActualizarTipoContacto(int idTipoContacto, CatTipoContactoModel tipoContacto)
        {
            tipoContacto.IdTipoContacto = idTipoContacto;
            return Ok(_service.ActualizarTipoContacto(tipoContacto));
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarTipoContactoLogico(int idTipoContacto, int idUsuario)
        {
            _service.EliminarTipoContactoLogico(idTipoContacto, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idTipoContacto}")]
        public IActionResult EliminarTipoContactoFisico(int idTipoContacto)
        {
            try
            {
                _service.EliminarTipoContactoFisico(idTipoContacto);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("No se puede eliminar el registro porque está siendo utilizado"))
                {
                    return Conflict(new { message = ex.Message });
                }
                return StatusCode(500, new { message = "Ocurrió un error interno.", details = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error inesperado.", details = ex.Message });
            }
        }
    }
}
