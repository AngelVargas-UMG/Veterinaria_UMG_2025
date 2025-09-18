using api_veterinaria.src.controller.Catalogo.Especies;
using api_veterinaria.src.controller.Catalogo.Estado;
using api_veterinaria.src.controller.Catalogo.EstadoSalud;
using api_veterinaria.src.controller.Mascotas;
using api_veterinaria.src.controller.Usuarios;
using api_veterinaria.src.shared.BD;
using api_veterinaria.src.shared.Interface;
using Microsoft.AspNetCore.Connections;

namespace api_veterinaria.src.controller
{
    public static class MainController
    {
        public static IServiceCollection AddController(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IDbConnectionFactory>(new SqlConnectionFactory(connectionString)); //POR SI QUIERES AGREGAR UNA CONEXION A BASE DE DATOS
            services.AddScoped<MascotasController>();
            services.AddScoped<UsuariosController>();



            services.AddScoped<EspeciesController>();
            services.AddScoped<UsuarioController>();
            services.AddScoped<EstadoSaludController>();
            return services;
        }
    }
}
