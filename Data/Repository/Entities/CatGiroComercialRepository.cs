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

        public CatGiroComercialModel CrearGiroComercial(CatGiroComercialModel giroComercial)
        {
            try {
                //_context.Database.ExecuteSqlRaw("EXEC sp_CrearCatGiroComercial @GiroComercial = {0}, @IdUsuarioAlta = {1}",
                //giroComercial.GiroComercial, giroComercial.IdUsuarioAlta);

                var registro = _context.CatGiroComercialModel
                    .FromSqlRaw("EXEC sp_CrearCatGiroComercial @GiroComercial = {0}, @IdUsuarioAlta = {1}",
                    giroComercial.GiroComercial, giroComercial.IdUsuarioAlta)
                    .AsEnumerable()
                    .FirstOrDefault();

                if (registro == null)
                {
                    throw new InvalidOperationException("No se encontró el registro después de crear el giro comercial");
                }

                return registro;
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

        public CatGiroComercialModel ActualizarGiroComercial(CatGiroComercialModel giroComercial)
        {
            try{
                // _context.Database.ExecuteSqlRaw("EXEC sp_ActualizarCatGiroComercial @IdGiroComercial = {0}, @GiroComercial = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}",
                //giroComercial.IdGiroComercial, giroComercial.GiroComercial, giroComercial.IdUsuarioModificacion, giroComercial.Activo);
                var resultado = _context.CatGiroComercialModel
                .FromSqlRaw("EXEC sp_ActualizarCatGiroComercial @IdGiroComercial = {0}, @GiroComercial = {1}, @IdUsuarioModificacion = {2}, @Activo = {3}",
                    giroComercial.IdGiroComercial, giroComercial.GiroComercial, giroComercial.IdUsuarioModificacion, giroComercial.Activo)
                .AsEnumerable()
                .FirstOrDefault();

                    if (resultado == null)
                    {
                        throw new InvalidOperationException("No se encontró el registro después de actualizar el giro comercial");
                    }

                return resultado;
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
