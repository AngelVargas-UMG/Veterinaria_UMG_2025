using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'HistorialMedico'
    public class HistorialMedico
    {
        [Key]
        public int HistorialID { get; set; }

        public int MascotaID { get; set; }
        [ForeignKey("MascotaID")]
        public virtual Mascota Mascota { get; set; } = new Mascota();

        public DateTime FechaRegistro { get; set; }
        public string? Descripcion { get; set; }

        public int VeterinarioID { get; set; }
        [ForeignKey("VeterinarioID")]
        public virtual Veterinario Veterinario { get; set; } = new Veterinario();
    }
}
