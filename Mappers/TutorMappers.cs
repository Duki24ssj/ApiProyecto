using ApiProyecto.DTOs.Aula;
using ApiProyecto.DTOs.Tutor;
using ApiProyecto.Models;

namespace ApiProyecto.Mappers
{
    public static class TutorMappers
    {
        public static TutorDto ToAulaDto(this Tutor TutorModel)
        {
            return new TutorDto
            {
                ID_Tutor = TutorModel.ID_Tutor,
                Nombre = TutorModel.Nombre,
                Apellido = TutorModel.Apellido,
                Telefono = TutorModel.Telefono,
                Correo = TutorModel.Correo,
              
            };
        }
        public static Tutor ToEstudianteFromCreateDTO(this CreateTutorDto TutorDto)
        {
            return new Tutor
            {
                Nombre = TutorDto.Nombre,
                Apellido = TutorDto.Apellido,
                Telefono = TutorDto.Telefono,
                Correo = TutorDto.Correo,
               

            };
        }
    }
}
