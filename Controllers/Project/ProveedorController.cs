using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PadronProveedoresAPI.Services.Project;

namespace PadronProveedoresAPI.Controllers.Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : Controller
    {

        private readonly ProveedorService _service;

        public ProveedorController(ProveedorService proveedorService)
        { 
            _service = proveedorService;
        }


        [HttpGet("ByNumeroProveedor/{NumeroProveedor}")]
        public async Task<IActionResult> GetProveedorByNumeroProveedor(string NumeroProveedor)
        {
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
