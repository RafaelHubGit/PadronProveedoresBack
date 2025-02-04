using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.MiddleWare.Logs;
using PadronProveedoresAPI.Services.Project;

namespace PadronProveedoresAPI.Controllers.Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeSenseController : Controller
    {
        private readonly TypeSenseService _typeSenseService;
        private readonly CustomLogger _logger;
        public TypeSenseController(
            TypeSenseService typeSenseService,
            CustomLogger logger
            )
        {
            _typeSenseService = typeSenseService;
            _logger = logger;
        }


        [HttpGet("index")]
        public async Task<ActionResult> TypeSenseIndex()
        {
            try {
                await _typeSenseService.IndexaPorveedores();
                return Ok();
            } catch ( Exception ex) {
                _logger.LogErrorWithContext(
                    "Error al indexar proveedores a TypeSense",
                    ex,
                    "TypeSenseController"
                    );
                return StatusCode(500, "Ocurrio un error interno.");
            }
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAllProveedores()
        {
            try{
                var proveedoresTS = await _typeSenseService.GetAllDocumentsAsync();
                return Ok(proveedoresTS);
            } catch ( Exception ex) {
                _logger.LogErrorWithContext(
                    "(GetAllProveedores) Error al consultar proveedores desde TypeSense",
                    ex,
                    "TypeSenseController"
                    );
                return StatusCode( 500, "Ocurrio un error interno.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProveedoresQuery(
            [FromQuery] string searchTerm, 
            [FromQuery] int pageNumber = 1, 
            [FromQuery] int pageSize = 250)
        {
            try{
                var proveedoresTs = await _typeSenseService.GetProveedoresQuery("proveedores",searchTerm, pageNumber, pageSize);
                return Ok(proveedoresTs);
            } catch ( Exception ex) {
                _logger.LogErrorWithContext(
                    "(GetProveedoresQuery) Error al consultar proveedores desde TypeSense",
                    ex,
                    "TypeSenseController",
                    ("searchTerm", searchTerm),
                    ("pageNumber", pageNumber),
                    ("pageSize", pageSize)
                    );
                return StatusCode( 500, "Ocurrio un error interno.");
            }
        }
    }
}
