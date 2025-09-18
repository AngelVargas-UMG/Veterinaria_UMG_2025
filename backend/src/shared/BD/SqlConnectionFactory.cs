using api_veterinaria.src.shared.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace api_veterinaria.src.shared.BD
{
    public class SqlConnectionFactory(string connectionString) : IDbConnectionFactory
    {
        private readonly string _connectionString = connectionString;

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);//POR SI QUIERES AGREGAR UNA CONEXION A BASE DE DATOS
        }
    }
}
