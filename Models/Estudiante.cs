using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models
{
    public class Estudiante
    {
        [Key]
        public int ID_Estudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Grado { get; set; }
        public string Grupo { get; set; }
        public string Usuario_Registro { get; set; }
        public DateTime Fecha_Registro { get; set; }

        // 🔗 Relaciones
        public virtual ICollection<Rotacion> Rotaciones { get; set; } = new List<Rotacion>();
    }
}
