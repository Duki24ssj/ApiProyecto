using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models
{
    public class Rotacion
    {
        [Key]
        public int ID_Rotacion { get; set; }

        [ForeignKey("Producto")]
        public int ID_Producto { get; set; }

        [ForeignKey("Estudiante")]
        public int ID_Estudiante { get; set; }

        [ForeignKey("Tutor")]
        public int ID_Tutor { get; set; }

        [ForeignKey("Turno")]
        public int ID_Turno { get; set; }

        public int Cantidad_Entregada { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public DateTime? Fecha_Recepcion { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public string Usuario_Registro { get; set; }
        public DateTime Fecha_Registro { get; set; }

        // 🔗 Relaciones
        public virtual Turno? Turno { get; set; }
    }
}
