using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatCodigosPostalesController : ControllerBase
    {
        private readonly CatCodigosPostalesService _service;

        public CatCodigosPostalesController(CatCodigosPostalesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCodigosPostales()
        {
            return Ok(_service.ObtenerCodigosPostales());
        }

        [HttpGet("{idCodigoPostal}")]
        public IActionResult GetCodigoPostalPorId(int idCodigoPostal)
        {
            return Ok(_service.ObtenerCodigoPostalPorId(idCodigoPostal));
        }

        [HttpGet("colonia/{idColonia}")]
        public IActionResult GetCodigosPostalesPorIdColonia(int idColonia)
        {
            return Ok(_service.ObtenerCodigosPostalesPorIdColonia(idColonia));
        }
    }
}
