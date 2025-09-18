
using api_veterinaria.src.controller.Catalogo.Estado;
using Microsoft.AspNetCore.Mvc;

namespace api_veterinaria.src.routes
{
    public static class Estado
    {
        public static IEndpointRouteBuilder MapEstadoEnpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("", async (
                    [FromServices] UsuarioController estadoController,
                    CancellationToken ct) =>
            {
                return await estadoController.ObtenerTodosEstados();
            })
                .WithName("ListarEstados")
                .WithTags("Estados - Obtener Estados")
                .Produces(StatusCodes.Status200OK);
            return app;
        }
    }
}
