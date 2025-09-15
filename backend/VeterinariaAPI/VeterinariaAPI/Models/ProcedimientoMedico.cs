using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'ProcedimientosMedicos'
    public class ProcedimientoMedico
    {
        [Key]
        public int ProcedimientoID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal? Costo { get; set; }
        public bool EsVacuna { get; set; }
    }
}
