namespace ApiProyecto.DTOs.Rotacion
{
    public class UpdateRotacionDto
    {
        public int ID_Producto { get; set; }
        public int ID_Estudiante { get; set; }
        public int ID_Tutor { get; set; }
        public int ID_Turno { get; set; }

        public int Cantidad_Entregada { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public DateTime? Fecha_Recepcion { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public string Usuario_Registro { get; set; }
        public DateTime Fecha_Registro { get; set; }
    }
}
