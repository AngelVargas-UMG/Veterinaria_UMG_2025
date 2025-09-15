using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'VisitaProcedimientos'
    public class VisitaProcedimiento
    {
        [Key]
        public int VisitaProcedimientoID { get; set; }

        public int VisitaID { get; set; }
        [ForeignKey("VisitaID")]
        public virtual Visita Visita { get; set; } = new Visita();

        public int ProcedimientoID { get; set; }
        [ForeignKey("ProcedimientoID")]
        public virtual ProcedimientoMedico Procedimiento { get; set; } = new ProcedimientoMedico();

        public int? Cantidad { get; set; }
        public decimal? CostoUnitario { get; set; }
        public decimal? Subtotal { get; set; }
        public string? EstadoProcedimiento { get; set; }
    }
}
