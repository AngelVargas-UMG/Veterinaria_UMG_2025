using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'Especie'
    public class Especie
    {
        [Key]
        public int EspecieID { get; set; }
        public string NombreEspecie { get; set; } = string.Empty;
    }
}
