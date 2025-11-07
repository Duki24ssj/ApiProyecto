namespace ApiProyecto.DTOs.Estudiante
{
    public class UpdateEstudianteDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Grado { get; set; } = string.Empty;
        public string Grupo { get; set; } = string.Empty;
        public string Usuario_Registro { get; set; } = string.Empty;
        public DateTime Fecha_Registro { get; set; }
    }
}
