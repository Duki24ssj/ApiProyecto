using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models
{
    public class Auditoria_General
    {
        [Key]
        public int ID_Auditoria { get; set; }

        public string Nombre_Tabla { get; set; }
        public int ID_Registro { get; set; }
        public string Accion { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalles { get; set; }
    }
}
