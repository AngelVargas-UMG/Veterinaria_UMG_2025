namespace api_veterinaria.src.routes
{
    public static class RouteMain
    {
        public static void MapEndpoints(this WebApplication app)
        {
            // Grupo base para todos los catálogos
            var urlApiGraph = app.MapGroup("/api/veterinaria");

            urlApiGraph.MapGroup("/mascotas").MapMascotasEndpoints();
            urlApiGraph.MapGroup("/usuarios").MapUsuariosEnpoint();


            urlApiGraph.MapGroup("/especies").MapEspeciesEndpoint();
            urlApiGraph.MapGroup("/estado").MapEstadoEnpoint();
            urlApiGraph.MapGroup("/estadoSalud").MapEstadoSaludEnpoint();
        }
    }
}
