using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models
{
    public class Estudiante
    {
        [Key]
        public int ID_Estudiante { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; }

        [Required, MaxLength(50)]
        public string Apellido { get; set; }

        [Required, MaxLength(20)]
        public string Grado { get; set; }

        [Required, MaxLength(20)]
        public string Grupo { get; set; }

        public string Usuario_Registro { get; set; }
        public DateTime Fecha_Registro { get; set; }

        // 🔗 Relaciones
        public virtual ICollection<Rotacion> Rotaciones { get; set; }
    }
}
