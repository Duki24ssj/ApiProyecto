using ApiProyecto.DTOs.Aula;
using ApiProyecto.DTOs.RegistroEntrada;
using ApiProyecto.Models;

namespace ApiProyecto.Mappers
{
    public static class RegistroEntradaMappers
    {
        public static RegistroEntradaDto ToRegistroEntradaDto(this Registro_Entrada RegistroEntradaModel)
        {
            return new RegistroEntradaDto
            {
                ID_Registro_Entrada = RegistroEntradaModel.ID_Registro_Entrada,
                ID_Producto = RegistroEntradaModel.ID_Producto,
                Cantidad_Disponible = RegistroEntradaModel.Cantidad_Disponible,
                Umbral_Minimo = RegistroEntradaModel.Umbral_Minimo,
                Fecha_Ingreso = RegistroEntradaModel.Fecha_Ingreso,
              
            };
        }
        public static Registro_Entrada ToRegistro_EntradaFromCreateDTO(this CreateRegistroEntradaDto RegistroEntradaDto)
        {
            return new Registro_Entrada
            {
                ID_Producto = RegistroEntradaDto.ID_Producto,
                Cantidad_Disponible = RegistroEntradaDto.Cantidad_Disponible,
                Umbral_Minimo = RegistroEntradaDto.Umbral_Minimo,
                Fecha_Ingreso = RegistroEntradaDto.Fecha_Ingreso,


            };
        }
    }
}
