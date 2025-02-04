using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PadronProveedoresAPI.MiddleWare.Logs;
using PadronProveedoresAPI.Services.Project;

namespace PadronProveedoresAPI.Controllers.Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : Controller
    {

        private readonly ProveedorService _service;
        private readonly CustomLogger _logger;

        public ProveedorController(
            ProveedorService proveedorService,
            CustomLogger logger
        )
        { 
            _service = proveedorService;
            _logger = logger;
        }


        [HttpGet("ByNumeroProveedor/{NumeroProveedor}")]
        public async Task<IActionResult> GetProveedorByNumeroProveedor(string NumeroProveedor)
        {
            _logger.LogInformationWithContext(
                "Consultando proveedor con número: {NumeroProveedor}",
                "ProveedorController",
                ("NumeroProveedor", NumeroProveedor),
                ("Usuario", "usuario"),
                ("RequestPath", HttpContext.Request.Path),
                ("RequestMethod", HttpContext.Request.Method)
            );


            var proveedores = await _service.GetProveedorByNumeroProveedorAsync(NumeroProveedor);

            return Ok(proveedores);
        }

        [HttpGet("scroll")]
        public async Task<IActionResult> GetProveedorScroll(int offset = 0, int pageSize = 10)
        {
            var proveedores = await _service.GetProveedorScrollAsync(offset, pageSize);

            if (proveedores.IsNullOrEmpty()) {
                return NoContent();
            }
            return Ok(proveedores);

        }
    }
}
