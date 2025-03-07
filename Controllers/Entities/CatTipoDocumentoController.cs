using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatTipoDocumentoController : ControllerBase
    {
        private readonly CatTipoDocumentoService _service;

        public CatTipoDocumentoController(CatTipoDocumentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTiposDocumentos()
        {
            return Ok(_service.ObtenerTiposDocumentos());
        }

        [HttpGet("{idTipoDocumento}")]
        public IActionResult GetTipoDocumentoPorId(int idTipoDocumento)
        {
            return Ok(_service.ObtenerTipoDocumentoPorId(idTipoDocumento));
        }

        [HttpPost]
        public IActionResult CrearTipoDocumento(CatTipoDocumentoModel tipoDocumento)
        {
            return Ok(_service.CrearTipoDocumento(tipoDocumento));
        }

        [HttpPut("{idTipoDocumento}")]
        public IActionResult ActualizarTipoDocumento(int idTipoDocumento, CatTipoDocumentoModel tipoDocumento)
        {
            tipoDocumento.IdTipoDocumento = idTipoDocumento;
            return Ok(_service.ActualizarTipoDocumento(tipoDocumento));
        }

        [HttpPatch("eliminarLogico")]
        public IActionResult EliminarTipoDocumentoLogico(int idTipoDocumento, int idUsuario)
        {
            _service.EliminarTipoDocumentoLogico(idTipoDocumento, idUsuario);
            return NoContent();
        }

        [HttpDelete("{idTipoDocumento}")]
        public IActionResult EliminarTipoDocumentoFisico(int idTipoDocumento)
        {
            try
            {
                _service.EliminarTipoDocumentoFisico(idTipoDocumento);
                return NoContent(); // Registro eliminado correctamente
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("No se puede eliminar el registro porque está siendo utilizado"))
                {
                    return Conflict(new { message = ex.Message }); // Código 409 para manejarlo en el front
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
