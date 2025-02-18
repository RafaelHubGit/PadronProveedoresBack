using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatEstratificacionController : ControllerBase
    {
        private readonly CatEstratificacionService _service;

        public CatEstratificacionController(CatEstratificacionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEstratificaciones()
        {
            return Ok(_service.ObtenerEstratificaciones());
        }

        [HttpGet("{idEstratificacion}")]
        public IActionResult GetEstratificacionPorId(int idEstratificacion)
        {
            return Ok(_service.ObtenerEstratificacionPorId(idEstratificacion));
        }

        [HttpPost]
        public IActionResult CrearEstratificacion(CatEstratificacionModel estratificacion)
        {
            return Ok(_service.CrearEstratificacion(estratificacion));
        }

        [HttpPut("{idEstratificacion}")]
        public IActionResult ActualizarEstratificacion(int idEstratificacion, CatEstratificacionModel estratificacion)
        {
            estratificacion.IdEstratificacion = idEstratificacion;
            return Ok(_service.ActualizarEstratificacion(estratificacion));
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarEstratificacionLogico(int idEstratificacion, int idUsuario)
        {
            _service.EliminarEstratificacionLogico(idEstratificacion, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idEstratificacion}")]
        public IActionResult EliminarEstratificacionFisico(int idEstratificacion)
        {
            try
            {
                _service.EliminarEstratificacionFisico(idEstratificacion);
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
