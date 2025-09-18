using api_veterinaria.src.controller.Catalogo.Especies;
using Microsoft.AspNetCore.Mvc;

namespace api_veterinaria.src.routes
{
    public static class Especies
    {
        public static IEndpointRouteBuilder MapEspeciesEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("", async (
                    [FromServices] EspeciesController especiesController,
                    CancellationToken ct) =>
            {
                return await especiesController.ObtenerTodasEspecies();
            })
                .WithName("ListarEspecies")
                .WithTags("Especies - Obtener Especies")
                .Produces(StatusCodes.Status200OK);
            return app;
        }
    }
}
