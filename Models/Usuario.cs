using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models
{
    public class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contraseña { get; set; }

        [ForeignKey("Rol")]
        public int ID_Rol { get; set; }

        // 🔗 Relaciones
        public Rol? Rol { get; set; }
    }
}
