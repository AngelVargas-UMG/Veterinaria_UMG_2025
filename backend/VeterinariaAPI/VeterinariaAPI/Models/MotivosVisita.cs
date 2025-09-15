using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'MotivosVisita'
    public class MotivosVisita
    {
        [Key]
        public int MotivoID { get; set; }
        public string DescripcionMotivo { get; set; } = string.Empty;
    }
}
