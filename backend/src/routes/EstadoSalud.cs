

using api_veterinaria.src.controller.Catalogo.EstadoSalud;
using Microsoft.AspNetCore.Mvc;

namespace api_veterinaria.src.routes
{
    public static class EstadoSalud
    {
        public static IEndpointRouteBuilder MapEstadoSaludEnpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("", async (
                    [FromServices] EstadoSaludController estadoSaludController,
                    CancellationToken ct) =>
            {
                return await estadoSaludController.ObtenerTodoEstadoSalud();
            })
                .WithName("ListarEstadoSalud")
                .WithTags("EstadoSalud - Obtener Estado Salud")
                .Produces(StatusCodes.Status200OK);
            return app;
        }
    }
}
