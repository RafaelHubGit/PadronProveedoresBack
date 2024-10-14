using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Models.Entities;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenProveedorGiroComercialController : ControllerBase
    {
        private readonly GenProveedorGiroComercialService _service;

        public GenProveedorGiroComercialController(GenProveedorGiroComercialService service)
        {
            _service = service;
        }

        //[HttpGet]
        //public IActionResult GetProveedoresGiroComercial()
        //{
        //    return Ok(_service.ObtenerProveedoresGiroComercial());
        //}

        //[HttpGet("{idProveedorGiroComercial}")]
        //public IActionResult GetProveedorGiroComercialPorId(int idProveedorGiroComercial)
        //{
        //    return Ok(_service.ObtenerProveedorGiroComercialPorId(idProveedorGiroComercial));
        //}

        //[HttpPost]
        //public IActionResult CrearProveedorGiroComercial(GenProveedorGiroComercialModel proveedorGiroComercial)
        //{
        //    _service.CrearProveedorGiroComercial(proveedorGiroComercial);
        //    return CreatedAtAction(nameof(GetProveedorGiroComercialPorId), new { idProveedorGiroComercial = proveedorGiroComercial.IdProveedor_GiroComercial }, proveedorGiroComercial);
        //}

        //[HttpPut("{idProveedorGiroComercial}")]
        //public IActionResult ActualizarProveedorGiroComercial(int idProveedorGiroComercial, GenProveedorGiroComercialModel proveedorGiroComercial)
        //{
        //    proveedorGiroComercial.IdProveedor_GiroComercial = idProveedorGiroComercial;
        //    _service.ActualizarProveedorGiroComercial(proveedorGiroComercial);
        //    return NoContent();
        //}

        //[HttpPatch("{idProveedorGiroComercial}/estado")]
        //public IActionResult EliminarProveedorGiroComercialLogico(int idProveedorGiroComercial, int idUsuarioModificacion)
        //{
        //    _service.EliminarProveedorGiroComercialLogico(idProveedorGiroComercial, idUsuarioModificacion);
        //    return NoContent();
        //}

        //[HttpDelete("{idProveedorGiroComercial}")]
        //public IActionResult EliminarProveedorGiroComercialFisico(int idProveedorGiroComercial)
        //{
        //    _service.EliminarProveedorGiroComercialFisico(idProveedorGiroComercial);
        //    return NoContent();
        //}
    }
}
