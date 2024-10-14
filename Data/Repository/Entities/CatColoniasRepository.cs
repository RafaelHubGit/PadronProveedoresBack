using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class CatColoniasRepository
    {
        private readonly StoreContext _context;

        public CatColoniasRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<CatColoniasModel> ObtenerColonias()
        {
            return _context.CatColoniasModel
                .FromSqlRaw("EXEC sp_ObtenerColonias")
                .ToList();
        }

        public CatColoniasModel ObtenerColoniaPorId(int idColonia)
        {
            return _context.CatColoniasModel
                .FromSqlRaw("EXEC sp_ObtenerColoniaPorId @IdColonia = {0}", idColonia)
                .FirstOrDefault();
        }

        public IEnumerable<CatColoniasModel> ObtenerColoniasPorIdMunicipio(int idMunicipio)
        {
            return _context.CatColoniasModel
                .FromSqlRaw("EXEC sp_ObtenerColoniasPorIdMunicipio @IdMunicipio = {0}", idMunicipio)
                .ToList();
        }
    }
}
