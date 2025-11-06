namespace ApiProyecto.DTOs.RegistroSalida
{
    public class RegistroSalidaDto
    {
        public int ID_Registro_Salida { get; set; }
        public int ID_Producto { get; set; }
        public int ID_Tutor { get; set; }
        public int ID_Aula { get; set; }
        public int ID_Turno { get; set; }
        public string Producto { get; set; } = string.Empty;
        public string Tutor { get; set; } = string.Empty;
        public string Aula { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;
        public int Cantidad_Entregada { get; set; }
        public DateTime? Fecha_Salida { get; set; }
    }
}
