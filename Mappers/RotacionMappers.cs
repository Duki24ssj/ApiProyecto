using ApiProyecto.DTOs.Aula;
using ApiProyecto.DTOs.Rotacion;
using ApiProyecto.Models;

namespace ApiProyecto.Mappers
{
    public static class RotacionMappers
    {
        public static RotacionDto ToAulaDto(this Rotacion RotacionModel)
        {
            return new RotacionDto
            {
                ID_Rotacion = RotacionModel.ID_Rotacion,
                ID_Producto = RotacionModel.ID_Producto,
                ID_Estudiante = RotacionModel.ID_Estudiante,
                ID_Tutor = RotacionModel.ID_Tutor,
                ID_Turno = RotacionModel.ID_Turno,
                Cantidad_Entregada = RotacionModel.Cantidad_Entregada,
                Fecha_Entrega = RotacionModel.Fecha_Entrega,
                Fecha_Recepcion = RotacionModel.Fecha_Recepcion,
                Estado = RotacionModel.Estado,
                Observaciones = RotacionModel.Observaciones,
                Usuario_Registro = RotacionModel.Usuario_Registro,
                Fecha_Registro = RotacionModel.Fecha_Registro,
               
            };
        }
        public static Rotacion ToEstudianteFromCreateDTO(this CreateRotacionDto RotacionDto)
        {
            return new Rotacion
            {
                ID_Producto = RotacionDto.ID_Producto,
                ID_Estudiante = RotacionDto.ID_Estudiante,
                ID_Tutor = RotacionDto.ID_Tutor,
                ID_Turno = RotacionDto.ID_Turno,
                Cantidad_Entregada = RotacionDto.Cantidad_Entregada,
                Fecha_Entrega = RotacionDto.Fecha_Entrega,
                Fecha_Recepcion = RotacionDto.Fecha_Recepcion,
                Estado = RotacionDto.Estado,
                Observaciones = RotacionDto.Observaciones,
                Usuario_Registro = RotacionDto.Usuario_Registro,
                Fecha_Registro = RotacionDto.Fecha_Registro,
              

            };
        }
    }
}
