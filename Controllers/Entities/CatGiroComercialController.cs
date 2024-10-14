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
            _service.CrearGiroComercial(giroComercial);
            return CreatedAtAction(nameof(GetGiroComercialPorId), new { idGiroComercial = giroComercial.IdGiroComercial }, giroComercial);
        }

        [HttpPut("{idGiroComercial}")]
        public IActionResult ActualizarGiroComercial(int idGiroComercial, CatGiroComercialModel giroComercial)
        {
            giroComercial.IdGiroComercial = idGiroComercial;
            _service.ActualizarGiroComercial(giroComercial);
            return NoContent();
        }

        [HttpPatch("{idGiroComercial}/estado")]
        public IActionResult EliminarGiroComercialLogico(int idGiroComercial)
        {
            _service.EliminarGiroComercialLogico(idGiroComercial);
            return NoContent();
        }

        [HttpDelete("{idGiroComercial}")]
        public IActionResult EliminarGiroComercialFisico(int idGiroComercial)
        {
            _service.EliminarGiroComercialFisico(idGiroComercial);
            return NoContent();
        }
    }
}
