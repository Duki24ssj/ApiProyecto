namespace ApiProyecto.DTOs.Usuario
{
    public class UsuarioDto
    {
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public int ID_Rol { get; set; }
        public string RolNombre { get; set; } = string.Empty; // solo para mostrar
    }
}
