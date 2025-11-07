using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.DTOs.Estudiante
{
    public class EstudianteDto
    {
        [Key]
        public int ID_Estudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; } 
        public string Grado { get; set; }
        public string Grupo { get; set; } 
        public string Usuario_Registro { get; set; } 
        public DateTime Fecha_Registro { get; set; }
    }
}
