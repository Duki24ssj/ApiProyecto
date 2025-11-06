using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models
{
    public class Turno
    {
        [Key]
        public int ID_Turno { get; set; }
        public string Nombre_Turno { get; set; }

        // 🔗 Relaciones
        public virtual ICollection<Registro_Salida> RegistrosSalida { get; set; }
        public virtual ICollection<Rotacion> Rotaciones { get; set; }
    }
}
