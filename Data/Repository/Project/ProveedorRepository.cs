using Dapper;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        private DataAccessHelper _dataAccessHelper = new DataAccessHelper();

        public ProveedorRepository(StoreContext storeContext)
        {
            _context = storeContext;
        }

        // NumProveedor se puede envir con el sig formato, solo un numero 1 o separado por comas 1, 2, 3
        public async Task<string> GetProveedorByNumeroProveedorAsync(string NumProveedor)
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

        public async Task<string> GetAllProveedoresAsync()
        {

            await using var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            command.CommandText = "EXEC sp_ObtenerProveedoresPorNumeroProveedor";

            using (var result = await command.ExecuteReaderAsync())
            {
                return await _dataAccessHelper.LeerJsonDesdeResultSetAsync(result);
            }

        }

        public async Task<string> GetProveedorScrollAsync(int page = 1, int pageSize = 10)
        {
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
        }



        private async Task<(DbConnection, DbDataReader)> EjecutarConsultaAsync(string comandoTexto, SqlParameter[] parametros = null)
        {
            await using var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            command.CommandText = comandoTexto;
            command.Parameters.AddRange(parametros ?? new SqlParameter[0]);

            var reader = await command.ExecuteReaderAsync();
            return (connection, reader);
        }
    }
}
