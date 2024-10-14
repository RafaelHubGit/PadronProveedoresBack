using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class CatMunicipiosRepository
    {
        private readonly StoreContext _context;

        public CatMunicipiosRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<CatMunicipiosModel> ObtenerMunicipios()
        {
            return _context.CatMunicipiosModel
                .FromSqlRaw("EXEC sp_ObtenerMunicipios")
                .ToList();
        }

        public CatMunicipiosModel ObtenerMunicipioPorId(int idMunicipio)
        {
            return _context.CatMunicipiosModel
                .FromSqlRaw("EXEC sp_ObtenerMunicipioPorId @IdMunicipio = {0}", idMunicipio)
                .FirstOrDefault();
        }

        public IEnumerable<CatMunicipiosModel> ObtenerMunicipiosPorIdEstado(int idEstado)
        {
            return _context.CatMunicipiosModel
                .FromSqlRaw("EXEC sp_ObtenerMunicipiosPorIdEstado @IdEstado = {0}", idEstado)
                .ToList();
        }
    }
}
