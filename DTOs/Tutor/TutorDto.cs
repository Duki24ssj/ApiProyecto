using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.DTOs.Tutor
{
    public class TutorDto
    {
        [Key]
        public int ID_Tutor { get; set; }
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public string Telefono { get; set; } 
        public string Correo { get; set; } 
    }
}
