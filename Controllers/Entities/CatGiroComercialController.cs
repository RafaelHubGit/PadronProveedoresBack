using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatGiroComercialController : ControllerBase
    {
        private readonly CatGiroComercialService _service;

        public CatGiroComercialController(CatGiroComercialService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetGirosComerciales()
        {
            return Ok(_service.ObtenerGirosComerciales());
        }

        [HttpGet("{idGiroComercial}")]
        public IActionResult GetGiroComercialPorId(int idGiroComercial)
        {
            return Ok(_service.ObtenerGiroComercialPorId(idGiroComercial));
        }

        [HttpPost]
        public IActionResult CrearGiroComercial(CatGiroComercialModel giroComercial)
        {
            return Ok(_service.CrearGiroComercial(giroComercial));
            //return CreatedAtAction(nameof(GetGiroComercialPorId), new { idGiroComercial = giroComercial.IdGiroComercial }, giroComercial);
        }

        [HttpPut("{idGiroComercial}")]
        public IActionResult ActualizarGiroComercial(int idGiroComercial, CatGiroComercialModel giroComercial)
        {
            giroComercial.IdGiroComercial = idGiroComercial;
            return Ok(_service.ActualizarGiroComercial(giroComercial));
            //return NoContent();
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarGiroComercialLogico(int idGiroComercial, int idUsuario)
        {
            _service.EliminarGiroComercialLogico(idGiroComercial, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idGiroComercial}")]
        public IActionResult EliminarGiroComercialFisico(int idGiroComercial)
        {
            try
            {
                _service.EliminarGiroComercialFisico(idGiroComercial);
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
