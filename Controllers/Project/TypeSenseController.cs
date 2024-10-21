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

    }
}
