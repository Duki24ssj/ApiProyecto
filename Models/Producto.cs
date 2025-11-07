using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models
{
    public class Producto
    {
        [Key]
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public int? Stock { get; set; }

        // 🔗 Relaciones
        public virtual ICollection<Registro_Entrada> RegistrosEntrada { get; set; } = new List<Registro_Entrada>();
        public virtual ICollection<Registro_Salida> RegistrosSalida { get; set; } = new List<Registro_Salida>();
        public virtual ICollection<Rotacion> Rotaciones { get; set; } = new List<Rotacion>();
    }
}
