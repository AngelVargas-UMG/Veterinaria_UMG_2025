using api_veterinaria.src.controller.Mascotas;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_veterinaria.src.routes
{
    public static class Mascotas
    {
        public static IEndpointRouteBuilder MapMascotasEndpoints(this IEndpointRouteBuilder app)
        {

            app.MapPost("", async (
                [FromQuery] string Nombre,
                [FromQuery] string Raza,
                [FromQuery] string Sexo,
                [FromQuery] string Color,
                [FromQuery] DateTime Nacimiento,
                [FromQuery] int EspecieID,
                [FromQuery] int EstadoSaludID,
                [FromQuery] int Usuario,
                [FromServices] MascotasController mascotasController,
                CancellationToken ct) =>
            {
                return await mascotasController.CrearMascota(Nombre,
                    Raza,
                    Sexo,
                    Color,
                    Nacimiento,
                    EspecieID,
                    EstadoSaludID,
                    Usuario);
            })
            .WithName("CrearMascotas")
            .WithTags("Mascotas - Crear Mascotas")
            .Produces(StatusCodes.Status200OK);

            app.MapGet("", async (
                [FromQuery] int? Id, [FromQuery] string? Nombre, [FromQuery] int? EspecieID,
                [FromServices] MascotasController mascotasController,
                CancellationToken ct) =>
            {
                return await mascotasController.ObtenerTodasMascotas(Id, Nombre, EspecieID);
            })
            .WithName("ListarMascotas")
            .WithTags("Mascotas - Obtener Mascotas")
            .Produces(StatusCodes.Status200OK);

            return app;
        }
    }
}
