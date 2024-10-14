using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenProveedorDatosController : ControllerBase
    {
        private readonly GenProveedorDatosService _service;

        public GenProveedorDatosController(GenProveedorDatosService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetProveedorDatos()
        {
            return Ok(_service.ObtenerProveedorDatos());
        }

        [HttpGet("{idProveedorDatos}")]
        public IActionResult GetProveedorDatosPorId(int idProveedorDatos)
        {
            return Ok(_service.ObtenerProveedorDatosPorId(idProveedorDatos));
        }

        [HttpPost]
        public IActionResult CrearProveedorDatos(GenProveedorDatosModel proveedorDatos)
        {
            _service.CrearProveedorDatos(proveedorDatos);
            return CreatedAtAction(nameof(GetProveedorDatosPorId), new { idProveedorDatos = proveedorDatos.IdProveedorDatos }, proveedorDatos);
        }

        [HttpPut("{idProveedorDatos}")]
        public IActionResult ActualizarProveedorDatos(int idProveedorDatos, GenProveedorDatosModel proveedorDatos)
        {
            proveedorDatos.IdProveedorDatos = idProveedorDatos;
            _service.ActualizarProveedorDatos(proveedorDatos);
            return NoContent();
        }

        [HttpPatch("{idProveedorDatos}/estado")]
        public IActionResult EliminarProveedorDatosLogico(int idProveedorDatos, int idUsuarioModificacion)
        {
            _service.EliminarProveedorDatosLogico(idProveedorDatos, idUsuarioModificacion);
            return NoContent();
        }

        [HttpDelete("{idProveedorDatos}")]
        public IActionResult EliminarProveedorDatosFisico(int idProveedorDatos)
        {
            _service.EliminarProveedorDatosFisico(idProveedorDatos);
            return NoContent();
        }
    }
}
