using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'Usuarios'
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string ContrasenaHash { get; set; } = string.Empty;

        public int EstadoID { get; set; }
        [ForeignKey("EstadoID")]
        public virtual Estado Estado { get; set; } = new Estado();

        public int RolID { get; set; }
        [ForeignKey("RolID")]
        public virtual Rol Rol { get; set; } = new Rol();
    }
}
