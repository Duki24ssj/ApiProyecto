namespace ApiProyecto.DTOs.RegistroEntrada
{
    public class UpdateRegistroEntradaDto
    {
        public int ID_Producto { get; set; }

        public int Cantidad_Disponible { get; set; }
        public int Umbral_Minimo { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
    }
}
