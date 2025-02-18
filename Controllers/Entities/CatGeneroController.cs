using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatGeneroController : ControllerBase
    {
        private readonly CatGeneroService _service;

        public CatGeneroController(CatGeneroService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetGeneros()
        {
            return Ok(_service.ObtenerGeneros());
        }

        [HttpGet("{idGenero}")]
        public IActionResult GetGeneroPorId(int idGenero)
        {
            return Ok(_service.ObtenerGeneroPorId(idGenero));
        }

        [HttpPost]
        public IActionResult CrearGenero(CatGeneroModel genero)
        {
            return Ok(_service.CrearGenero(genero));
        }

        [HttpPut("{idGenero}")]
        public IActionResult ActualizarGenero(int idGenero, CatGeneroModel genero)
        {
            genero.IdGenero = idGenero;
            return Ok(_service.ActualizarGenero(genero));
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarGeneroLogico(int idGenero, int idUsuario)
        {
            _service.EliminarGeneroLogico(idGenero, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idGenero}")]
        public IActionResult EliminarGeneroFisico(int idGenero)
        {
            try
            {
                _service.EliminarGeneroFisico(idGenero);
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
