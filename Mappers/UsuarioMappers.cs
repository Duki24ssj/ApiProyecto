using ApiProyecto.DTOs.Aula;
using ApiProyecto.DTOs.Usuario;
using ApiProyecto.Models;

namespace ApiProyecto.Mappers
{
    public static class UsuarioMappers
    {
        public static UsuarioDto ToUsuarioDto(this Usuario UsuarioModel)
        {
            return new UsuarioDto
            {
                ID_Usuario = UsuarioModel.ID_Usuario,
                Nombre_Usuario = UsuarioModel.Nombre_Usuario,
                Contraseña = UsuarioModel.Contraseña,
                ID_Rol = UsuarioModel.ID_Rol,
            };
        }
        public static Usuario ToEstudianteFromCreateDTO(this CreateUsuarioDto UsuarioDto)
        {
            return new Usuario
            {
                Nombre_Usuario = UsuarioDto.Nombre_Usuario,
                Contraseña = UsuarioDto.Contraseña,
                ID_Rol = UsuarioDto.ID_Rol,

            };
        }
    }
}
