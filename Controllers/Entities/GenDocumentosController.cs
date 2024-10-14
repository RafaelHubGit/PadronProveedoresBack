using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenDocumentosController : ControllerBase
    {
        private readonly GenDocumentosService _service;

        public GenDocumentosController(GenDocumentosService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDocumentos()
        {
            return Ok(_service.ObtenerDocumentos());
        }

        [HttpGet("{idDocumentos}")]
        public IActionResult GetDocumentoPorId(int idDocumentos)
        {
            return Ok(_service.ObtenerDocumentoPorId(idDocumentos));
        }

        [HttpGet("proveedor/{idProveedorDatos}")]
        public IActionResult GetDocumentosPorProveedorDatos(int idProveedorDatos)
        {
            return Ok(_service.ObtenerDocumentosPorProveedorDatos(idProveedorDatos));
        }

        [HttpPost]
        public IActionResult CrearDocumento(GenDocumentosModel documento)
        {
            _service.CrearDocumento(documento);
            return CreatedAtAction(nameof(GetDocumentoPorId), new { idDocumentos = documento.IdDocumentos }, documento);
        }

        [HttpPut("{idDocumentos}")]
        public IActionResult ActualizarDocumento(int idDocumentos, GenDocumentosModel documento)
        {
            documento.IdDocumentos = idDocumentos;
            _service.ActualizarDocumento(documento);
            return NoContent();
        }

        [HttpPatch("{idDocumentos}/estado")]
        public IActionResult EliminarDocumentoLogico(int idDocumentos, int idUsuarioModificacion)
        {
            _service.EliminarDocumentoLogico(idDocumentos, idUsuarioModificacion);
            return NoContent();
        }

        [HttpDelete("{idDocumentos}")]
        public IActionResult EliminarDocumentoFisico(int idDocumentos)
        {
            _service.EliminarDocumentoFisico(idDocumentos);
            return NoContent();
        }
    }
}
