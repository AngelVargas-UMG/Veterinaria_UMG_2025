using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'Mascotas'
    public class Mascota
    {
        [Key]
        public int MascotaID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int EspecieID { get; set; }
        public string? Raza { get; set; }
        public string? Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Color { get; set; }
        public int UsuarioID { get; set; }
        public int? EstadoSaludID { get; set; }
        public int EstadoID { get; set; }

        [ForeignKey("EspecieID")]
        public virtual Especie Especie { get; set; } = new Especie();

        [ForeignKey("UsuarioID")]
        public virtual Usuario Usuario { get; set; } = new Usuario();

        [ForeignKey("EstadoSaludID")]
        public virtual EstadoSalud? EstadoSalud { get; set; }

        [ForeignKey("EstadoID")]
        public virtual Estado Estado { get; set; } = new Estado();
    }
}
