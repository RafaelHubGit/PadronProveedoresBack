using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenProveedorController : ControllerBase
    {
        private readonly GenProveedorService _service;

        public GenProveedorController(GenProveedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetGenProveedores()
        {
            return Ok(_service.ObtenerGenProveedor());
        }

        [HttpGet("{idProveedor}")]
        public IActionResult GetGenProveedorPorId(int idProveedor)
        {
            return Ok(_service.ObtenerProveedorPorId(idProveedor));
        }

        [HttpPost]
        public IActionResult CrearGenProveedor(GenProveedorModel proveedor)
        {
            _service.CrearProveedor(proveedor);
            return CreatedAtAction(nameof(GetGenProveedorPorId), new { idProveedor = proveedor.Id }, proveedor);
        }

        [HttpPut("{idProveedor}")]
        public IActionResult ActualizarGenProveedor(int idProveedor, GenProveedorModel proveedor)
        {
            proveedor.Id = idProveedor;
            _service.ActualizarProveedor(proveedor);
            return NoContent();
        }

        [HttpPatch("{idProveedor}/estado")]
        public IActionResult EliminarProveedorLogico(int idProveedor, int idUsuarioModificacion)
        {
            _service.EliminarProveedorLogico(idProveedor, idUsuarioModificacion);
            return NoContent();
        }

        [HttpDelete("{idProveedor}")]
        public IActionResult EliminarProveedorFisico(int idProveedor)
        {
            _service.EliminarProveedorFisico(idProveedor);
            return NoContent();
        }
    }
}
