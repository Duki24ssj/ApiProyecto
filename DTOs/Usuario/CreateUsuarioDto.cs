using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.DTOs.Usuario
{
    public class CreateUsuarioDto
    {
        public string Nombre_Usuario { get; set; }
        public string Contraseña { get; set; }
        public int ID_Rol { get; set; }
    }
}
