using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PadronProveedoresAPI.MiddleWare.Logs;

namespace PadronProveedoresAPI.Data.Repository
{
    public class GenericRepository
    {
        private readonly StoreContext _context;
        private readonly CustomLogger _logger;

        public GenericRepository(
            StoreContext context,
            CustomLogger logger
        )
        {
            _context = context;
            _logger = logger;
        }

        public void EjecutarStoredProcedure(string storedProcedure, params object[] parameters)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(storedProcedure, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogErrorWithContext(
                    $"Error ejecutando {storedProcedure}",
                    ex,
                    "Repositorio",  // Nombre de la clase o contexto donde ocurre el error
                    ("StoredProcedure", storedProcedure)
                );
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public IEnumerable<T> EjecutarStoredProcedureLista<T>(string storedProcedure, params object[] parameters) where T : class
        {
            try
            {
                return _context.Set<T>().FromSqlRaw(storedProcedure, parameters).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogErrorWithContext($"Error ejecutando {storedProcedure}", ex, typeof(T).Name);
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public T EjecutarStoredProcedureUnico<T>(string storedProcedure, params object[] parameters) where T : class
        {
            try
            {
                return _context.Set<T>().FromSqlRaw(storedProcedure, parameters).AsEnumerable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogErrorWithContext($"Error ejecutando {storedProcedure}", ex, typeof(T).Name);
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

        public void EliminarStoredProcedure(string storedProcedure, params object[] parameters)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(storedProcedure, parameters);
            }
            catch (SqlException ex) when (ex.Number == 547) // Error de clave foránea
            {
                // Si hay un error de integridad referencial, mostramos un mensaje específico
                throw new InvalidOperationException("No se puede eliminar el registro porque está siendo utilizado en otras relaciones.");
            }
            catch (Exception ex)
            {
                // Si ocurre otro error, lo manejamos aquí
                _logger.LogErrorWithContext(
                   $"Error ejecutando {storedProcedure}",
                   ex,
                   "Repositorio",  // Nombre de la clase o contexto donde ocurre el error
                   ("StoredProcedure", storedProcedure)
               );
                throw new Exception("Ocurrió un error interno.", ex);
            }
        }

    }
}
