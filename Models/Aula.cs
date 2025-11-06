using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models
{
    public class Aula
    {
        [Key]
        public int ID_Aula { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Tutor")]
        public int ID_Tutor { get; set; }


        // 🔗 Relaciones
        public virtual Tutor? Tutor { get; set; }
        public virtual ICollection<Registro_Salida> Registro_Salida { get; set; }
    }
}
