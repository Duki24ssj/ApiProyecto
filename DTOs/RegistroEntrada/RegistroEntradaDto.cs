namespace ApiProyecto.DTOs.RegistroEntrada
{
    public class RegistroEntradaDto
    {
        public int ID_Registro_Entrada { get; set; }
        public int ID_Producto { get; set; }
        public string Producto { get; set; } = string.Empty; // Nombre producto (procedimiento)
        public int Cantidad_Disponible { get; set; }
        public int Umbral_Minimo { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
    }
}
