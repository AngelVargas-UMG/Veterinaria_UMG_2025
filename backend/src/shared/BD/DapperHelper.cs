using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace GraphService.src.Shared.Services
{
    public static class DapperHelper
    {
        /**
         ES UN HELPER PARA EJECUTAR PROCEDIMIENTOS ALMACENADOS USANDO DAPPER
         */
        public static async Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(
            IDbConnection connection,
            string procedureName,
            object parameters = null)
        {
            if (connection is not SqlConnection sqlConnection)
                throw new InvalidOperationException("La conexión no es una SqlConnection.");

            await sqlConnection.OpenAsync();

            return await sqlConnection.QueryAsync<T>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
