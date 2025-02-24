using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatMatrizArticulosFraccionesController : ControllerBase
    {
        private readonly CatMatrizArticulosFraccionesService _service;

        public CatMatrizArticulosFraccionesController(CatMatrizArticulosFraccionesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetMatrizArticulosFracciones()
        {
            return Ok(_service.ObtenerMatrizArticulosFracciones());
        }

        [HttpGet("{idMatrizArticulosFracciones}")]
        public IActionResult GetMatrizArticulosFraccionesPorId(int idMatrizArticulosFracciones)
        {
            return Ok(_service.ObtenerMatrizArticulosFraccionesPorId(idMatrizArticulosFracciones));
        }

        [HttpPost]
        public IActionResult CrearMatrizArticulosFracciones(CatMatrizArticulosFraccionesModel matrizArticulosFracciones)
        {
            return Ok(_service.CrearMatrizArticulosFracciones(matrizArticulosFracciones));
        }

        [HttpPut("{idMatrizArticulosFracciones}")]
        public IActionResult ActualizarMatrizArticulosFracciones(int idMatrizArticulosFracciones, CatMatrizArticulosFraccionesModel matrizArticulosFracciones)
        {
            matrizArticulosFracciones.IdMatrizArticulosFracciones = idMatrizArticulosFracciones;
            return Ok(_service.ActualizarMatrizArticulosFracciones(matrizArticulosFracciones));
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarMatrizArticulosFraccionesLogico(int idMatrizArticulosFracciones, int idUsuario)
        {
            _service.EliminarMatrizArticulosFraccionesLogico(idMatrizArticulosFracciones, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idMatrizArticulosFracciones}")]
        public IActionResult EliminarMatrizArticulosFraccionesFisico(int idMatrizArticulosFracciones)
        {
            try
            {
                _service.EliminarMatrizArticulosFraccionesFisico(idMatrizArticulosFracciones);
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
