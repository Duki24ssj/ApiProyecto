using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models
{
    public class Rol
    {
        [Key]
        public int ID_Rol { get; set; }
        public string Nombre_Rol { get; set; }

        // 🔗 Relaciones
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
