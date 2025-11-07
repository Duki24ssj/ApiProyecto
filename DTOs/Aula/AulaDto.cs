using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.DTOs.Aula
{
    public class AulaDto
    {
        [Key]
        public int ID_Aula { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Tutor")]
        public int ID_Tutor { get; set; } 
    }
}
