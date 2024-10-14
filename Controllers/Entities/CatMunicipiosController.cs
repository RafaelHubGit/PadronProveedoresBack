using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatMunicipiosController : ControllerBase
    {
        private readonly CatMunicipiosService _service;

        public CatMunicipiosController(CatMunicipiosService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetMunicipios()
        {
            return Ok(_service.ObtenerMunicipios());
        }

        [HttpGet("{idMunicipio}")]
        public IActionResult GetMunicipioPorId(int idMunicipio)
        {
            return Ok(_service.ObtenerMunicipioPorId(idMunicipio));
        }

        [HttpGet("estado/{idEstado}")]
        public IActionResult GetMunicipiosPorIdEstado(int idEstado)
        {
            return Ok(_service.ObtenerMunicipiosPorIdEstado(idEstado));
        }
    }
}
