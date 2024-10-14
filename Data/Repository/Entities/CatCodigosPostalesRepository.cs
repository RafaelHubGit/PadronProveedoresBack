using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class CatCodigosPostalesRepository
    {
        private readonly StoreContext _context;

        public CatCodigosPostalesRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<CatCodigosPostalesModel> ObtenerCodigosPostales()
        {
            return _context.CatCodigosPostalesModel
                .FromSqlRaw("EXEC sp_ObtenerCodigosPostales")
                .ToList();
        }

        public CatCodigosPostalesModel ObtenerCodigoPostalPorId(int idCodigoPostal)
        {
            return _context.CatCodigosPostalesModel
                .FromSqlRaw("EXEC sp_ObtenerCodigoPostalPorId @IdCodigoPostal = {0}", idCodigoPostal)
                .FirstOrDefault();
        }

        public IEnumerable<CatCodigosPostalesModel> ObtenerCodigosPostalesPorIdColonia(int idColonia)
        {
            return _context.CatCodigosPostalesModel
                .FromSqlRaw("EXEC sp_ObtenerCodigosPostalesPorIdColonia @IdColonia = {0}", idColonia)
                .ToList();
        }
    }
}
