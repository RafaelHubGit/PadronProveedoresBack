using Microsoft.AspNetCore.Mvc;
using PadronProveedoresAPI.Services.Project;

namespace PadronProveedoresAPI.Controllers.Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeSenseController : Controller
    {
        private readonly TypeSenseService _typeSenseService;
        public TypeSenseController(TypeSenseService typeSenseService)
        {
            _typeSenseService = typeSenseService;
        }


        [HttpGet("index")]
        public async Task<ActionResult> TypeSenseIndex()
        {
            await _typeSenseService.IndexaPorveedores();
            return Ok();
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAllProveedores()
        {
            var proveedoresTS = await _typeSenseService.GetAllDocumentsAsync();
            return Ok(proveedoresTS);
        }

        [HttpGet]
        public async Task<IActionResult> GetProveedoresQuery(
            [FromQuery] string searchTerm, 
            [FromQuery] int pageNumber = 1, 
            [FromQuery] int pageSize = 250)
        {
            var proveedoresTs = await _typeSenseService.GetProveedoresQuery("proveedores",searchTerm, pageNumber, pageSize);
            return Ok(proveedoresTs);
        }
    }
}
