using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.MiddleWare.Logs;
using PadronProveedoresAPI.Models.Entities;

namespace PadronProveedoresAPI.Data.Repository.Entities
{
    public class CatGiroComercialRepository
    {
        private readonly StoreContext _context;
        private readonly CustomLogger _logger;

        public CatGiroComercialRepository(
            StoreContext context,
            CustomLogger logger
        )
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<CatGiroComercialModel> ObtenerGirosComerciales()
        {
            try {
                return _context.CatGiroComercialModel
                    .FromSqlRaw("EXEC sp_ObtenerCatGiroComercial")
                    .ToList();
            } catch (Exception ex) {
                _logger.LogErrorWithContext(
                    "Consultando Giros Comerciales",
                    ex,
                    "CatGiroComercialRepository",
                    ("Usuario", "usuario")
                );
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public CatGiroComercialModel ObtenerGiroComercialPorId(int idGiroComercial)
        {
            try { 
                return _context.CatGiroComercialModel
                    .FromSqlRaw("EXEC sp_ObtenerGiroComercialPorId @IdGiroComercial = {0}", idGiroComercial)
                    .FirstOrDefault();
            } catch (Exception ex)
            {
                _logger.LogErrorWithContext(
                    "Obteniendo Giros Comerciales por Id",
                    ex,
                    "CatGiroComercialRepository",
                    ("idGiroComercial", idGiroComercial),
                    ("Usuario", "usuario")
                );
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public void CrearGiroComercial(CatGiroComercialModel giroComercial)
        {
            try {
                _context.Database.ExecuteSqlRaw("EXEC sp_CrearGiroComercial @GiroComercial = {0}, @IdUsuarioAlta = {1}",
                giroComercial.GiroComercial, giroComercial.IdUsuarioAlta);
            }
            catch (Exception ex)
            {
                _logger.LogErrorWithContext(
                    "Creando Giro Comercial",
                    ex,
                    "CatGiroComercialRepository",
                    ("Giro Comercial", giroComercial),
                    ("Usuario", "usuario")
                );
                throw new Exception("Ocurrió un error interno.", ex);
            }
            
        }

        public void ActualizarGiroComercial(CatGiroComercialModel giroComercial)
        {
            try{
                _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarGiroComercial @IdGiroComercial = {0}, @GiroComercial = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}",
               giroComercial.IdGiroComercial, giroComercial.GiroComercial, giroComercial.IdUsuarioModificacion, giroComercial.Activo);
            } catch (Exception ex) {
                _logger.LogErrorWithContext(
                    "Actualizando Giro Comercial",
                    ex,
                    "CatGiroComercialRepository",
                    ("Giro Comercial", giroComercial),
                    ("Usuario", "usuario")
                );
                throw new Exception("Ocurrió un error interno.", ex);
            }
           
        }

        public void EliminarGiroComercialLogico(int idGiroComercial)
        {
            try{
                _context.Database.ExecuteSqlRaw("EXEC sp_EliminarGiroComercialLogico @IdGiroComercial = {0}", idGiroComercial);
            } catch (Exception ex) {
                _logger.LogErrorWithContext(
                    "Eliminando Giro Comercial Logico",
                    ex,
                    "CatGiroComercialRepository",
                    ("ID Giro Comercial", idGiroComercial),
                    ("Usuario", "usuario")
                );
                throw new Exception("Ocurrió un error interno.", ex);
            }
            
        }

        public void EliminarGiroComercialFisico(int idGiroComercial)
        {
            try{
                _context.Database.ExecuteSqlRaw("EXEC sp_EliminarGiroComercialFisico @IdGiroComercial = {0}", idGiroComercial);
            } catch (Exception ex) {
                _logger.LogErrorWithContext(
                    "Eliminando Giro Comercial Fisico",
                    ex,
                    "CatGiroComercialRepository",
                    ("ID Giro Comercial", idGiroComercial),
                    ("Usuario", "usuario")
                );
                throw new Exception("Ocurrió un error interno.", ex);
            }  
        }
    }
}
