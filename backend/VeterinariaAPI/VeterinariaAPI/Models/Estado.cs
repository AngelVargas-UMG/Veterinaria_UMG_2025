using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'Estado'
    public class Estado
    {
        [Key]
        public int EstadoID { get; set; }
        public string NombreEstado { get; set; } = string.Empty;
    }
}
