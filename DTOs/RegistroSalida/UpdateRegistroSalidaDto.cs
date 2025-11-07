namespace ApiProyecto.DTOs.RegistroSalida
{
    public class UpdateRegistroSalidaDto
    {
        public int ID_Producto { get; set; }
        public int ID_Tutor { get; set; }
        public int ID_Aula { get; set; }
        public int ID_Turno { get; set; }

        public int Cantidad_Entregada { get; set; }
        public DateTime? Fecha_Salida { get; set; }
    }
}
