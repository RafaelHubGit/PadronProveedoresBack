using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatEstatusProveedorBloqueadoController : ControllerBase
    {
        private readonly CatEstatusProveedorBloqueadoService _service;

        public CatEstatusProveedorBloqueadoController(CatEstatusProveedorBloqueadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEstatusProveedoresBloqueado()
        {
            return Ok(_service.ObtenerEstatusProveedoresBloqueados());
        }

        [HttpGet("{idEstatusProveedorBloqueado}")]
        public IActionResult GetEstatusProveedorBloqueadoPorId(int idEstatusProveedorBloqueado)
        {
            return Ok(_service.ObtenerEstatusProveedorBloqueadoPorId(idEstatusProveedorBloqueado));
        }

        [HttpPost]
        public IActionResult CrearEstatusProveedorBloqueado(CatEstatusProveedorBloqueadoModel estatusProveedorBloqueado)
        {
            return Ok(_service.CrearEstatusProveedorBloqueado(estatusProveedorBloqueado));
            //return CreatedAtAction(nameof(GetEstatusProveedorBloqueadoPorId), new { idEstatusProveedorBloqueado = estatusProveedorBloqueado.IdEstatusProveedorBloqueado }, estatusProveedorBloqueado);
        }

        [HttpPut("{idEstatusProveedorBloqueado}")]
        public IActionResult ActualizarEstatusProveedorBloqueado(int idEstatusProveedorBloqueado, CatEstatusProveedorBloqueadoModel estatusProveedorBloqueado)
        {
            estatusProveedorBloqueado.IdEstatusProveedorBloqueado = idEstatusProveedorBloqueado;
            return Ok(_service.ActualizarEstatusProveedorBloqueado(estatusProveedorBloqueado));
            //return NoContent();
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarEstatusProveedorBloqueadoLogico(int idEstatusProveedorBloqueado, int idUsuario)
        {
            _service.EliminarEstatusProveedorBloqueadoLogico(idEstatusProveedorBloqueado, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idEstatusProveedorBloqueado}")]
        public IActionResult EliminarEstatusProveedorBloqueadoFisico(int idEstatusProveedorBloqueado)
        {
            try
            {
                _service.EliminarEstatusProveedorBloqueadoFisico(idEstatusProveedorBloqueado);
                return NoContent(); // El registro fue eliminado correctamente
            }
            catch (InvalidOperationException ex)
            {
                // Si el error es de clave foránea (547), devolvemos un error 400 (Bad Request)
                if (ex.Message.Contains("No se puede eliminar el registro porque está siendo utilizado"))
                {
                    return Conflict(new { message = ex.Message }); //Regresa como codigo el 409 para poder manejarlo en el front
                }

                // Si es otro error, devolvemos un 500 (Internal Server Error)
                return StatusCode(500, new { message = "Ocurrió un error interno.", details = ex.Message });
            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de excepciones generales
                return StatusCode(500, new { message = "Ocurrió un error inesperado.", details = ex.Message });
            }
        }
    }
}
