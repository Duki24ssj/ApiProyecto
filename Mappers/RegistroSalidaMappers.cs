using ApiProyecto.DTOs.Aula;
using ApiProyecto.DTOs.RegistroSalida;
using ApiProyecto.Models;

namespace ApiProyecto.Mappers
{
    public static class RegistroSalidaMappers
    {
        public static RegistroSalidaDto ToAulaDto(this Registro_Salida RegistroSalidaModel)
        {
            return new RegistroSalidaDto
            {
                ID_Registro_Salida = RegistroSalidaModel.ID_Registro_Salida,
                ID_Producto = RegistroSalidaModel.ID_Producto,
                ID_Tutor = RegistroSalidaModel.ID_Tutor,
                ID_Aula = RegistroSalidaModel.ID_Aula,
                ID_Turno = RegistroSalidaModel.ID_Turno,
                Cantidad_Entregada = RegistroSalidaModel.Cantidad_Entregada,
                Fecha_Salida = RegistroSalidaModel.Fecha_Salida,
              
            };
        }
        public static Registro_Salida ToEstudianteFromCreateDTO(this CreateRegistroSalidaDto RegistroSalidaDto)
        {
            return new Registro_Salida
            {
                ID_Producto = RegistroSalidaDto.ID_Producto,
                ID_Tutor = RegistroSalidaDto.ID_Tutor,
                ID_Aula = RegistroSalidaDto.ID_Aula,
                ID_Turno = RegistroSalidaDto.ID_Turno,
                Cantidad_Entregada = RegistroSalidaDto.Cantidad_Entregada,
                Fecha_Salida = RegistroSalidaDto.Fecha_Salida,
               

            };
        }
    }
}
