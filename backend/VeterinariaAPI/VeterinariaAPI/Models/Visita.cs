using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'Visitas'
    public class Visita
    {
        [Key]
        public int VisitaID { get; set; }

        public int MascotaID { get; set; }
        [ForeignKey("MascotaID")]
        public virtual Mascota Mascota { get; set; } = new Mascota();

        public int VeterinarioID { get; set; }
        [ForeignKey("VeterinarioID")]
        public virtual Veterinario Veterinario { get; set; } = new Veterinario();

        public int OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public virtual Usuario Owner { get; set; } = new Usuario();

        public DateTime FechaVisita { get; set; }

        public int MotivoID { get; set; }
        [ForeignKey("MotivoID")]
        public virtual MotivosVisita Motivo { get; set; } = new MotivosVisita();

        public decimal? CostoConsulta { get; set; }
        public decimal? CostoTotal { get; set; }

        public int EstadoID { get; set; }
        [ForeignKey("EstadoID")]
        public virtual Estado Estado { get; set; } = new Estado();

        public string? Observaciones { get; set; }
    }
}
