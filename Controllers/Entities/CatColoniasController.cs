using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatColoniasController : ControllerBase
    {
        private readonly CatColoniasService _service;

        public CatColoniasController(CatColoniasService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetColonias()
        {
            return Ok(_service.ObtenerColonias());
        }

        [HttpGet("{idColonia}")]
        public IActionResult GetColoniaPorId(int idColonia)
        {
            return Ok(_service.ObtenerColoniaPorId(idColonia));
        }

        [HttpGet("municipio/{idMunicipio}")]
        public IActionResult GetColoniasPorIdMunicipio(int idMunicipio)
        {
            return Ok(_service.ObtenerColoniasPorIdMunicipio(idMunicipio));
        }
    }
}
