using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models
{
    public class Registro_Salida
    {
        [Key]
        public int ID_Registro_Salida { get; set; }

        [ForeignKey("Producto")]
        public int ID_Producto { get; set; }

        [ForeignKey("Tutor")]
        public int ID_Tutor { get; set; }

        [ForeignKey("Aula")]
        public int ID_Aula { get; set; }

        [ForeignKey("Turno")]
        public int ID_Turno { get; set; }

        public int Cantidad_Entregada { get; set; }
        public DateTime? Fecha_Salida { get; set; }

        // 🔗 Relaciones
       public virtual Producto? Producto { get; set; }
       public virtual Tutor? Tutor { get; set; }
       public virtual Aula? Aula { get; set; }
       public virtual Turno? Turno{ get; set; }
    }
}
