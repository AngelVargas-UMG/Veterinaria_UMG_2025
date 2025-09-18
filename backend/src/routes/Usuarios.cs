using api_veterinaria.src.controller.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace api_veterinaria.src.routes
{
    public static class Usuarios
    {
        public static IEndpointRouteBuilder MapUsuariosEnpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("", async (
                    [FromServices] UsuariosController usuarioController,
                    CancellationToken ct) =>
            {
                return await usuarioController.ObtenerTodosUsuarios();
            })
                .WithName("ListarUsuarios")
                .WithTags("Usuarios - Obtener Usuarios")
                .Produces(StatusCodes.Status200OK);
            app.MapPost("", async (
                [FromQuery] string Nombre,
                [FromQuery] string Apellido,
                [FromQuery] string Correo,
                [FromQuery] string Telefono,
                [FromQuery] string Direccion,
                [FromServices] UsuariosController usuarioController,
                    CancellationToken ct) =>
            {
                return await usuarioController.CrearUsuario(Nombre,Apellido,Correo,Telefono,Direccion);
            })
                .WithName("CrearUsuarios")
                .WithTags("Usuarios - Crear Usuario")
                .Produces(StatusCodes.Status200OK);
            return app;
        }
    }
}
