using api_veterinaria.src.modelos;
using api_veterinaria.src.shared.Interface;
using GraphService.src.Shared.Services;

namespace api_veterinaria.src.controller.Catalogo.Especies
{
    public class EspeciesController
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public EspeciesController(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        async public Task<IResult> ObtenerTodasEspecies()
        {
            /**USO SIMPLE DE UN CONSUMO A UN PROCEDIMIENTO ALMACENADO*/
            using var connection = _connectionFactory.CreateConnection();
            var result = await DapperHelper.ExecuteStoredProcedureAsync<EspecieModelo>(connection, "SpEspecieListar", new { });

            return Results.Ok(result);
        }

    }
}
