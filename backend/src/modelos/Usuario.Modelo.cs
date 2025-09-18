namespace api_veterinaria.src.modelos
{
    public class UsuarioModelo
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido
        { get; set; } = string.Empty;
        public string Email
        { get; set; } = string.Empty;
        public string Telefono
        { get; set; } = string.Empty;
        public string Direccion
        { get; set; } = string.Empty;
        public int EstadoID
        { get; set; }
        public int RolID
        { get; set; }
        public string NombreUsuario {  get; set; } = string.Empty;
    }
}
