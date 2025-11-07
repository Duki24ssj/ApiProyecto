using ApiProyecto.DTOs;
using ApiProyecto.DTOs.Aula;
using ApiProyecto.DTOs.Estudiante;
using ApiProyecto.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Mappers
{
    public static class AulaMappers
    {
        public static AulaDto ToAulaDto(this Aula AulaModel)
        {
            return new AulaDto
            {
                ID_Aula = AulaModel.ID_Aula,
                 Nombre = AulaModel.Nombre,
                ID_Tutor =  AulaModel.ID_Tutor
            };
        }
        public static Aula ToEstudianteFromCreateDTO(this CreateAulaDto AulaDto)
        {
            return new Aula
            {
                Nombre = AulaDto.Nombre,
                ID_Tutor = AulaDto.ID_Tutor,
               
            };
        }
    }
}

        
    

