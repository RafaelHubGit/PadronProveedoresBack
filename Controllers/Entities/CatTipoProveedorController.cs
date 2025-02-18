using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatTipoProveedorController : ControllerBase
    {
        private readonly CatTipoProveedorService _service;

        public CatTipoProveedorController(CatTipoProveedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTiposProveedor()
        {
            return Ok(_service.ObtenerTiposProveedor());
        }

        [HttpGet("{idTipoProveedor}")]
        public IActionResult GetTipoProveedorPorId(int idTipoProveedor)
        {
            return Ok(_service.ObtenerTipoProveedorPorId(idTipoProveedor));
        }

        [HttpPost]
        public IActionResult CrearTipoProveedor(CatTipoProveedorModel tipoProveedor)
        {
            return Ok(_service.CrearTipoProveedor(tipoProveedor));
        }

        [HttpPut("{idTipoProveedor}")]
        public IActionResult ActualizarTipoProveedor(int idTipoProveedor, CatTipoProveedorModel tipoProveedor)
        {
            tipoProveedor.IdTipoProveedor = idTipoProveedor;
            return Ok(_service.ActualizarTipoProveedor(tipoProveedor));
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarTipoProveedorLogico(int idTipoProveedor, int idUsuario)
        {
            _service.EliminarTipoProveedorLogico(idTipoProveedor, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idTipoProveedor}")]
        public IActionResult EliminarTipoProveedorFisico(int idTipoProveedor)
        {
            try
            {
                _service.EliminarTipoProveedorFisico(idTipoProveedor);
                return NoContent(); // El registro fue eliminado correctamente
            }
            catch (InvalidOperationException ex)
            {
                // Si el error es de clave foránea (547), devolvemos un error 400 (Bad Request)
                if (ex.Message.Contains("No se puede eliminar el registro porque está siendo utilizado"))
                {
                    return Conflict(new { message = ex.Message }); // Regresa como código el 409 para manejarlo en el front
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
