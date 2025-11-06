using System.ComponentModel.DataAnnotations;
using ApiProyecto.Models.Aula;

namespace ApiProyecto.Models
{
    public class Tutor
    {
        [Key]
        public int ID_Tutor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        // 🔗 Relaciones
        public virtual ICollection<Aula> Aulas { get; set; }
        public  virtual ICollection<Registro_Salida> RegistrosSalida { get; set; }
        public virtual ICollection<Rotacion> Rotaciones { get; set; }
    }
}
