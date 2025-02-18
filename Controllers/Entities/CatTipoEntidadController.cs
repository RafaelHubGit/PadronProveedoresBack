using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatTipoEntidadController : ControllerBase
    {
        private readonly CatTipoEntidadService _service;

        public CatTipoEntidadController(CatTipoEntidadService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTiposEntidad()
        {
            return Ok(_service.ObtenerTiposEntidad());
        }

        [HttpGet("{idTipoEntidad}")]
        public IActionResult GetTipoEntidadPorId(int idTipoEntidad)
        {
            return Ok(_service.ObtenerTipoEntidadPorId(idTipoEntidad));
        }

        [HttpPost]
        public IActionResult CrearTipoEntidad(CatTipoEntidadModel tipoEntidad)
        {
            return Ok(_service.CrearTipoEntidad(tipoEntidad));
        }

        [HttpPut("{idTipoEntidad}")]
        public IActionResult ActualizarTipoEntidad(int idTipoEntidad, CatTipoEntidadModel tipoEntidad)
        {
            tipoEntidad.IdTipoEntidad = idTipoEntidad;
            return Ok(_service.ActualizarTipoEntidad(tipoEntidad));
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarTipoEntidadLogico(int idTipoEntidad, int idUsuario)
        {
            _service.EliminarTipoEntidadLogico(idTipoEntidad, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idTipoEntidad}")]
        public IActionResult EliminarTipoEntidadFisico(int idTipoEntidad)
        {
            try
            {
                _service.EliminarTipoEntidadFisico(idTipoEntidad);
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
