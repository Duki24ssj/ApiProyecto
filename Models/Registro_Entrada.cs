using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models
{
    public class Registro_Entrada
    {
        [Key]
        public int ID_Registro_Entrada { get; set; }

        [ForeignKey("Producto")]
        public int ID_Producto { get; set; }

        public int Cantidad_Disponible { get; set; }
        public int Umbral_Minimo { get; set; }
        public DateTime Fecha_Ingreso { get; set; }

        // 🔗 Relaciones
        public virtual Producto? Producto { get; set; }
    }
}
