using Dapper;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PadronProveedoresAPI.MiddleWare.Logs;
using PadronProveedoresAPI.Utilities;
using System.Data;
using System.Data.Common;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PadronProveedoresAPI.Data.Repository.Project
{
    public class ProveedorRepository
    {

        private StoreContext _context;
        private readonly CustomLogger _logger;
        private DataAccessHelper _dataAccessHelper;

        public ProveedorRepository(
            StoreContext storeContext,
            CustomLogger logger
        )
        {
            _context = storeContext;
            _logger = logger;
            _dataAccessHelper = new DataAccessHelper(_logger);
        }

        // NumProveedor se puede envir con el sig formato, solo un numero 1 o separado por comas 1, 2, 3
        public async Task<string> GetProveedorByNumeroProveedorAsync(string NumProveedor)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();
                using var command = connection.CreateCommand();

                command.CommandText = "EXEC sp_ObtenerProveedoresPorNumeroProveedor @NumeroProveedor";
                command.Parameters.Add(new SqlParameter("@NumeroProveedor", NumProveedor));

                using (var result = await command.ExecuteReaderAsync())
                {
                    //return await _dataAccessHelper.LeerJsonDesdeResultSetAsync(result);
                    var json = await _dataAccessHelper.LeerJsonDesdeResultSetAsync(result);
                    await result.CloseAsync(); // Cierra explícitamente el reader
                    return json;
                }
            }
            catch (Exception ex) {
                _logger.LogErrorWithContext(
                    "Consultando proveedor con número: {NumeroProveedor}",
                    ex,
                    "ProveedorController",
                    ("NumeroProveedor", NumProveedor),
                    ("Usuario", "usuario")
                );
                throw new Exception("Ocurrió un error interno.", ex);
            }

        }

        //public async Task<string> GetAllProveedoresAsync( string NumerosProveedor = "" )
        //{
        //    try {
        //        await using var connection = _context.Database.GetDbConnection();
        //        await connection.OpenAsync();
        //        using var command = connection.CreateCommand();
        //        command.CommandText = "EXEC sp_ObtenerProveedoresPorNumeroProveedor @NumerosProveedor";
        //        command.Parameters.Add(new SqlParameter("@NumerosProveedor", NumerosProveedor));

        //        using (var result = await command.ExecuteReaderAsync())
        //        {
        //            return await _dataAccessHelper.LeerJsonDesdeResultSetAsync(result);
        //        }
        //    } catch ( Exception ex ){
        //        _logger.LogErrorWithContext(
        //            "(GetAllProveedoresAsync) Error al consultar proveedor ",
        //            ex,
        //            "ProveedorRepository",
        //            ("Usuario", "usuario")
        //        );
        //        throw new Exception("Ocurrió un error interno.", ex);
        //    } 


        //}

        public async Task<string> GetAllProveedoresAsync(string NumerosProveedor = "", int pageSize = 100, int pageNumber = 1)
        {
            try
            {
                var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync(); // Abrir la conexion manualmente
                using var command = connection.CreateCommand();
                command.CommandText = "EXEC sp_ObtenerProveedoresPorNumeroProveedor @NumerosProveedor, @PageSize, @PageNumber";
                command.Parameters.Add(new SqlParameter("@NumerosProveedor", NumerosProveedor));
                command.Parameters.Add(new SqlParameter("@PageSize", pageSize));
                command.Parameters.Add(new SqlParameter("@PageNumber", pageNumber));

                // Aumentar el tiempo de espera a 120 segundos (2 minutos)
                command.CommandTimeout = 120;

                using (var result = await command.ExecuteReaderAsync())
                {
                    return await _dataAccessHelper.LeerJsonDesdeResultSetAsync(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogErrorWithContext(
                    "(GetAllProveedoresAsync) Error al consultar proveedor ",
                    ex,
                    "ProveedorRepository",
                    ("Usuario", "usuario")
                );
                throw new Exception("Ocurrió un error interno.", ex);
            }
            finally
            {
                // Cerrar la conexión manualmente si está abierta
                if (_context.Database.GetDbConnection().State == System.Data.ConnectionState.Open)
                {
                    await _context.Database.GetDbConnection().CloseAsync();
                }
            }
        }

        public async Task<string> GetProveedorScrollAsync(int page = 1, int pageSize = 10)
        {
            try {
                if (page < 1)
                {
                    page = 1;
                }
                var offset = (page - 1) * pageSize;

                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();
                using var command = connection.CreateCommand();

                command.CommandText = "EXEC sp_ObtenerProveedoresScroll @Offset, @PageSize";
                command.Parameters.Add(new SqlParameter("@Offset", offset));
                command.Parameters.Add(new SqlParameter("@PageSize", pageSize));

                using (var result = await command.ExecuteReaderAsync())
                {
                    return await _dataAccessHelper.LeerJsonDesdeResultSetAsync(result);
                }
            } catch ( Exception ex ){
                _logger.LogErrorWithContext(
                    "(GetProveedorScrollAsync), Error al consultar proveedor ",
                    ex,
                    "ProveedorRepository",
                    ("Page", page),
                    ("pageSize", pageSize),
                    ("Usuario", "usuario")
                );
                throw new Exception("Ocurrió un error interno.", ex);
            } 
        }



        private async Task<(DbConnection, DbDataReader)> EjecutarConsultaAsync(string comandoTexto, SqlParameter[] parametros = null)
        {
            try
            {
                await using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();
                using var command = connection.CreateCommand();
                command.CommandText = comandoTexto;
                command.Parameters.AddRange(parametros ?? new SqlParameter[0]);

                var reader = await command.ExecuteReaderAsync();
                return (connection, reader);
            }
            catch (Exception ex) {
                _logger.LogErrorWithContext(
                    "(EjecutarConsultaAsync), Error al consultar proveedor ",
                    ex,
                    "ProveedorRepository",
                    ("comandoTexto", comandoTexto),
                    ("parametros", parametros),
                    ("Usuario", "usuario")
                );
                throw new Exception("Ocurrió un error interno.", ex);
            } 
        }
    }
}
