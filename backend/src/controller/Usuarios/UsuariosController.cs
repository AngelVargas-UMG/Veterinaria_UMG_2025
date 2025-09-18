using api_veterinaria.src.modelos;
using api_veterinaria.src.shared.Interface;
using GraphService.src.Shared.Services;

namespace api_veterinaria.src.controller.Usuarios
{
    public class UsuariosController
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UsuariosController(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async public Task<IResult> CrearUsuario(string Nombre, string Apellido, string Correo, string Telefono, string Direccion)
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = await DapperHelper.ExecuteStoredProcedureAsync<int>(connection, "SpUsuarioCrear", new { Nombre = Nombre, Apellido = Apellido, Correo = Correo, Telefono = Telefono, Direccion = Direccion});

            return Results.Ok(result);
        }
        async public Task<IResult> ObtenerTodosUsuarios()
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = await DapperHelper.ExecuteStoredProcedureAsync<UsuarioModelo>(connection, "SpUsuarioListar", new { });

            return Results.Ok(result);
        }
    }
}
