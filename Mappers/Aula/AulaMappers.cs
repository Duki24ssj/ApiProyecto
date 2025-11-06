using ApiProyecto.DTOs.Aula;
using ApiProyecto.DTOs;
using ApiProyecto.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Mappers.Aula
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

    }
}

        
    

