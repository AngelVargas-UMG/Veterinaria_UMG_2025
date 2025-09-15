using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'Roles'
    public class Rol
    {
        [Key]
        public int RolID { get; set; }
        public string NombreRol { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}
