using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Services.Entities;

namespace PadronProveedoresAPI.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatEstadosController : ControllerBase
    {
        private readonly CatEstadosService _service;

        public CatEstadosController(CatEstadosService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEstados()
        {
            return Ok(_service.ObtenerEstados());
        }

        [HttpGet("{idEstado}")]
        public IActionResult GetEstadoPorId(int idEstado)
        {
            return Ok(_service.ObtenerEstadoPorId(idEstado));
        }
    }
}
