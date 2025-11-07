using ApiProyecto.DTOs.Estudiante;
using ApiProyecto.Models;

namespace ApiProyecto.Mappers
{
    public static class EstudianteMappers
    {
        public static EstudianteDto ToEstudianteDto(this Estudiante estudianteModel)
        {
            return new EstudianteDto
            {
                ID_Estudiante = estudianteModel.ID_Estudiante,
                Nombre = estudianteModel.Nombre,
                Apellido = estudianteModel.Apellido,
                Grado = estudianteModel.Grado,
                Grupo = estudianteModel.Grupo,
                Usuario_Registro = estudianteModel.Usuario_Registro,
                Fecha_Registro = estudianteModel.Fecha_Registro


            };
        }
        public static Estudiante ToEstudianteFromCreateDTO(this CreateEstudianteDto EstudianteDto)
        {
            return new Estudiante
            {
                Nombre = EstudianteDto.Nombre,
                Apellido = EstudianteDto.Apellido,
                Grado = EstudianteDto.Grado,
                Grupo = EstudianteDto.Grupo,
                Usuario_Registro = EstudianteDto.Usuario_Registro,
                Fecha_Registro = EstudianteDto.Fecha_Registro,
            };
        }
    }
}
