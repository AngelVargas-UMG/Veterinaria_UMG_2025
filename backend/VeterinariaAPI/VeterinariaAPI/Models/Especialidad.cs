using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Models
{
    // Modelo de entidad para la tabla 'Especialidad'
    public class Especialidad
    {
        [Key]
        public int EspecialidadID { get; set; }
        public string NombreEspecialidad { get; set; } = string.Empty;
    }
}
