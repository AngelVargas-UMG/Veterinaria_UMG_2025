using api_veterinaria.src.modelos;
using api_veterinaria.src.shared.Interface;
using GraphService.src.Shared.Services;

namespace api_veterinaria.src.controller.Catalogo.Estado
{
    public class UsuarioController
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UsuarioController(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async public Task<IResult> ObtenerTodosEstados()
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = await DapperHelper.ExecuteStoredProcedureAsync<EstadoModelo>(connection, "SpEstadoListar", new { });

            return Results.Ok(result);
        }
    }
}
