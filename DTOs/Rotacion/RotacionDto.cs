namespace ApiProyecto.DTOs.Rotacion
{
    public class RotacionDto
    {
        public int ID_Rotacion { get; set; }
        public int ID_Producto { get; set; }
        public string Producto { get; set; } = string.Empty;
        public int ID_Estudiante { get; set; }
        public string Estudiante { get; set; } = string.Empty;
        public int ID_Tutor { get; set; }
        public string Tutor { get; set; } = string.Empty;
        public int ID_Turno { get; set; }
        public string Turno { get; set; } = string.Empty;
        public int Cantidad_Entregada { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public DateTime? Fecha_Recepcion { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public string Usuario_Registro { get; set; } = string.Empty;
        public DateTime Fecha_Registro { get; set; }
    }
}
