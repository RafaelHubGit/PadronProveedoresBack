using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class CatEstadosRepository
    {
        private readonly StoreContext _context;

        public CatEstadosRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<CatEstadosModel> ObtenerEstados()
        {
            return _context.CatEstadosModel
                .FromSqlRaw("EXEC sp_ObtenerEstados")
                .ToList();
        }

        public CatEstadosModel ObtenerEstadoPorId(int idEstado)
        {
            return _context.CatEstadosModel
                .FromSqlRaw("EXEC sp_ObtenerEstadoPorId @IdEstado = {0}", idEstado)
                .FirstOrDefault();
        }
    }
}
