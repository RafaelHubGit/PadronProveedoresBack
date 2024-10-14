﻿using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Text;

namespace PadronProveedoresAPI.Utilities
{
    public class DataAccessHelper
    {

        /// <summary>
        /// Lee un conjunto de resultados de una consulta SQL y los convierte en una cadena JSON.
        /// </summary>
        /// <param name="result">El conjunto de resultados de la consulta SQL.</param>
        /// <returns>Una cadena JSON que representa los datos del conjunto de resultados.</returns>
        public async Task<string> LeerJsonDesdeResultSetAsync(DbDataReader result)
        {
            // Crea un objeto StringBuilder para eficientemente construir la cadena JSON
            var jsonBuilder = new StringBuilder();

            // Lee cada fila del conjunto de resultados
            while (await result.ReadAsync())
            {
                // Si ya hay contenido en la cadena JSON, agrega una coma para separar los elementos
                if (!string.IsNullOrEmpty(jsonBuilder.ToString()))
                {
                    jsonBuilder.Append(",");
                }

                // Obtiene el valor de la primera columna de la fila actual y lo agrega a la cadena JSON
                jsonBuilder.Append(result.GetString(0));
            }

            // Obtiene la cadena JSON completa
            var jsonString = jsonBuilder.ToString();

            // Si la cadena JSON no está vacía, la envuelve en corchetes para convertirla en un arreglo JSON
            if (!string.IsNullOrEmpty(jsonString))
            {
                jsonString = $"[{jsonString}]";
            }

            // Retorna la cadena JSON
            return jsonString;
        }
    }
}