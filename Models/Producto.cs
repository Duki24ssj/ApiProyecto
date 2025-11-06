using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models
{
    public class Producto
    {
        [Key]
        public int ID_Producto { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        public int? Stock { get; set; }

        // 🔗 Relaciones
        public virtual ICollection<Registro_Entrada> RegistrosEntrada { get; set; }
        public virtual ICollection<Registro_Salida> RegistrosSalida { get; set; }
        public virtual ICollection<Rotacion> Rotaciones { get; set; }
    }
}
