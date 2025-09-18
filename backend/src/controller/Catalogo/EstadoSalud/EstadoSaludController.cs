using api_veterinaria.src.modelos;
using api_veterinaria.src.shared.Interface;
using GraphService.src.Shared.Services;

namespace api_veterinaria.src.controller.Catalogo.EstadoSalud
{
    public class EstadoSaludController
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public EstadoSaludController(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async public Task<IResult> ObtenerTodoEstadoSalud()
        {
            using var connection = _connectionFactory.CreateConnection();
            var result = await DapperHelper.ExecuteStoredProcedureAsync<EstadoSaludModelo>(connection, "SpEstadoSaludListar", new { });

            return Results.Ok(result);
        }
    }
}
