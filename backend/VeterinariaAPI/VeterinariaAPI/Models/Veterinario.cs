using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'Veterinarios'
    public class Veterinario
    {
        [Key]
        public int VeterinarioID { get; set; }

        public int UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public virtual Usuario Usuario { get; set; } = new Usuario();

        public string? NumeroLicencia { get; set; }

        public int? EspecialidadID { get; set; }
        [ForeignKey("EspecialidadID")]
        public virtual Especialidad? Especialidad { get; set; }

        public string? HorarioAtencion { get; set; }
        public string? Notas { get; set; }
    }
}
