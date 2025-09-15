using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'EstadoSalud'
    public class EstadoSalud
    {
        [Key]
        public int EstadoSaludID { get; set; }
        public string NombreEstadoSalud { get; set; } = string.Empty;
    }
}
