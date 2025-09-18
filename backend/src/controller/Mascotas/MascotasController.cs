using api_veterinaria.src.modelos;
using api_veterinaria.src.routes;
using api_veterinaria.src.shared.Interface;
using GraphService.src.Shared.Services;

namespace api_veterinaria.src.controller.Mascotas
{
    public class MascotasController
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public MascotasController(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // Este es el método que contiene la lógica que quieres ejecutar.
        // Recibe los parámetros que necesita y devuelve un resultado.
        async public Task<IResult> CrearMascota(string Nombre, string Raza, string Sexo, string Color, DateTime Nacimiento, int EspecieID, int EstadoSaludID, int Usuario)
        {
            // --- AQUÍ VA TODA TU LÓGICA ---
            // Por ejemplo: buscar en la base de datos, validar, etc.
            if (string.IsNullOrEmpty(Nombre))
            {
                return Results.BadRequest("El ID de la mascota es requerido.");
            }
            /**USO SIMPLE DE UN CONSUMO A UN PROCEDIMIENTO ALMACENADO*/
            using var connection = _connectionFactory.CreateConnection();
            var result = await DapperHelper.ExecuteStoredProcedureAsync<int>(connection, "SpMascotaCrear", new {
                Nombre = Nombre,
                Raza = Raza,
                Sexo = Sexo,
                Color = Color,
                Nacimiento = Nacimiento,
                EspecieID = EspecieID,
                EstadoSaludID = EstadoSaludID,
                Usuario = Usuario,
            });

            // Simulamos que encontramos una mascota
            //var mascota = new { Id = id, Nombre = "Firulais", Especie = "Perro" };

            // Results.Ok() es la forma estándar de devolver una respuesta 200 OK con datos.
            return Results.Ok(result);
        }
        async public Task<IResult> ObtenerTodasMascotas(int? IdMascota, string? Nombre, int? EspecieID)
        {
            /**USO SIMPLE DE UN CONSUMO A UN PROCEDIMIENTO ALMACENADO*/
            using var connection = _connectionFactory.CreateConnection();
            var result = await DapperHelper.ExecuteStoredProcedureAsync<MascotasModelo>(connection, "SpMascotaListar", new { IdMascota = IdMascota, Nombre = Nombre , IdEspecie = EspecieID });

            return Results.Ok(result);
        }
    }
}
