using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class CatGiroComercialRepository
    {
        private readonly StoreContext _context;

        public CatGiroComercialRepository(StoreContext context)
        {
            _context = context;
        }

        public IEnumerable<CatGiroComercialModel> ObtenerGirosComerciales()
        {
            return _context.CatGiroComercialModel
                .FromSqlRaw("EXEC sp_ObtenerGirosComerciales")
                .ToList();
        }

        public CatGiroComercialModel ObtenerGiroComercialPorId(int idGiroComercial)
        {
            return _context.CatGiroComercialModel
                .FromSqlRaw("EXEC sp_ObtenerGiroComercialPorId @IdGiroComercial = {0}", idGiroComercial)
                .FirstOrDefault();
        }

        public void CrearGiroComercial(CatGiroComercialModel giroComercial)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_CrearGiroComercial @GiroComercial = {0}, @IdUsuarioAlta = {1}",
                giroComercial.GiroComercial, giroComercial.IdUsuarioAlta);
        }

        public void ActualizarGiroComercial(CatGiroComercialModel giroComercial)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarGiroComercial @IdGiroComercial = {0}, @GiroComercial = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}",
                giroComercial.IdGiroComercial, giroComercial.GiroComercial, giroComercial.IdUsuarioModificacion, giroComercial.Activo);
        }

        public void EliminarGiroComercialLogico(int idGiroComercial)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarGiroComercialLogico @IdGiroComercial = {0}", idGiroComercial);
        }

        public void EliminarGiroComercialFisico(int idGiroComercial)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_EliminarGiroComercialFisico @IdGiroComercial = {0}", idGiroComercial);
        }
    }
}
