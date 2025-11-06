using ApiProyecto.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RotacionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RotacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Rotacion
        [HttpGet]
        public IActionResult MostrarRotacion()
        {
            var lista = new List<RotacionDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("MostrarRotacion", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new RotacionDto
                        {
                            ID_Rotacion = rdr.GetInt32(rdr.GetOrdinal("ID_Rotacion")),
                            ID_Producto = rdr.GetInt32(rdr.GetOrdinal("ID_Producto")),
                            Producto = rdr["Producto"].ToString() ?? string.Empty,
                            ID_Estudiante = rdr.GetInt32(rdr.GetOrdinal("ID_Estudiante")),
                            Estudiante = rdr["Estudiante"].ToString() ?? string.Empty,
                            ID_Tutor = rdr.GetInt32(rdr.GetOrdinal("ID_Tutor")),
                            Tutor = rdr["Tutor"].ToString() ?? string.Empty,
                            ID_Turno = rdr.GetInt32(rdr.GetOrdinal("ID_Turno")),
                            Turno = rdr["Turno"].ToString() ?? string.Empty,
                            Cantidad_Entregada = rdr.GetInt32(rdr.GetOrdinal("Cantidad_Entregada")),
                            Fecha_Entrega = rdr.GetDateTime(rdr.GetOrdinal("Fecha_Entrega")),
                            Fecha_Recepcion = rdr.IsDBNull(rdr.GetOrdinal("Fecha_Recepcion")) ? null : (DateTime?)rdr.GetDateTime(rdr.GetOrdinal("Fecha_Recepcion")),
                            Estado = rdr["Estado"].ToString() ?? string.Empty,
                            Observaciones = rdr["Observaciones"].ToString() ?? string.Empty,
                            Usuario_Registro = rdr["Usuario_Registro"].ToString() ?? string.Empty,
                            Fecha_Registro = rdr.GetDateTime(rdr.GetOrdinal("Fecha_Registro"))
                        });
                    }
                }
            }
            return Ok(lista);
        }

        // POST: api/Rotacion
        [HttpPost]
        public IActionResult InsertarRotacion([FromBody] RotacionDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("InsertarRotacion", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Producto", dto.ID_Producto);
                cmd.Parameters.AddWithValue("@ID_Estudiante", dto.ID_Estudiante);
                cmd.Parameters.AddWithValue("@ID_Tutor", dto.ID_Tutor);
                cmd.Parameters.AddWithValue("@ID_Turno", dto.ID_Turno);
                cmd.Parameters.AddWithValue("@Cantidad_Entregada", dto.Cantidad_Entregada);
                cmd.Parameters.AddWithValue("@Fecha_Entrega", dto.Fecha_Entrega.Date);
                if (dto.Fecha_Recepcion.HasValue)
                    cmd.Parameters.AddWithValue("@Fecha_Recepcion", dto.Fecha_Recepcion.Value);
                else
                    cmd.Parameters.AddWithValue("@Fecha_Recepcion", DBNull.Value);

                cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(dto.Estado) ? "Entregado" : dto.Estado);
                cmd.Parameters.AddWithValue("@Observaciones", string.IsNullOrWhiteSpace(dto.Observaciones) ? (object)DBNull.Value : dto.Observaciones);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Rotación insertada correctamente");
        }

        // PUT: api/Rotacion/{id}
        [HttpPut("{id}")]
        public IActionResult ActualizarRotacion(int id, [FromBody] RotacionDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("ActualizarRotacion", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Rotacion", id);
                cmd.Parameters.AddWithValue("@ID_Producto", dto.ID_Producto);
                cmd.Parameters.AddWithValue("@ID_Estudiante", dto.ID_Estudiante);
                cmd.Parameters.AddWithValue("@ID_Tutor", dto.ID_Tutor);
                cmd.Parameters.AddWithValue("@ID_Turno", dto.ID_Turno);
                cmd.Parameters.AddWithValue("@Cantidad_Entregada", dto.Cantidad_Entregada);
                cmd.Parameters.AddWithValue("@Fecha_Entrega", dto.Fecha_Entrega.Date);
                if (dto.Fecha_Recepcion.HasValue)
                    cmd.Parameters.AddWithValue("@Fecha_Recepcion", dto.Fecha_Recepcion.Value);
                else
                    cmd.Parameters.AddWithValue("@Fecha_Recepcion", DBNull.Value);

                cmd.Parameters.AddWithValue("@Estado", dto.Estado ?? string.Empty);
                cmd.Parameters.AddWithValue("@Observaciones", string.IsNullOrWhiteSpace(dto.Observaciones) ? (object)DBNull.Value : dto.Observaciones);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Rotación actualizada correctamente");
        }

        // DELETE: api/Rotacion/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarRotacion(int id)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("EliminarRotacion", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Rotacion", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Rotación eliminada correctamente");
        }

        // GET: api/Rotacion/buscar/producto/{nombre}
        [HttpGet("buscar/producto/{nombre}")]
        public IActionResult BuscarRotacionPorProducto(string nombre)
        {
            var lista = new List<RotacionDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("BuscarRotacionPorProducto", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProducto", nombre);
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new RotacionDto
                        {
                            ID_Rotacion = rdr.GetInt32(rdr.GetOrdinal("ID_Rotacion")),
                            ID_Producto = rdr.GetInt32(rdr.GetOrdinal("ID_Producto")),
                            Producto = rdr["Producto"].ToString() ?? string.Empty,
                            ID_Estudiante = rdr.GetInt32(rdr.GetOrdinal("ID_Estudiante")),
                            Estudiante = rdr["Estudiante"].ToString() ?? string.Empty,
                            ID_Tutor = rdr.GetInt32(rdr.GetOrdinal("ID_Tutor")),
                            Tutor = rdr["Tutor"].ToString() ?? string.Empty,
                            ID_Turno = rdr.GetInt32(rdr.GetOrdinal("ID_Turno")),
                            Turno = rdr["Turno"].ToString() ?? string.Empty,
                            Cantidad_Entregada = rdr.GetInt32(rdr.GetOrdinal("Cantidad_Entregada")),
                            Fecha_Entrega = rdr.GetDateTime(rdr.GetOrdinal("Fecha_Entrega")),
                            Fecha_Recepcion = rdr.IsDBNull(rdr.GetOrdinal("Fecha_Recepcion")) ? null : (DateTime?)rdr.GetDateTime(rdr.GetOrdinal("Fecha_Recepcion")),
                            Estado = rdr["Estado"].ToString() ?? string.Empty,
                            Observaciones = rdr["Observaciones"].ToString() ?? string.Empty,
                            Usuario_Registro = rdr["Usuario_Registro"].ToString() ?? string.Empty,
                            Fecha_Registro = rdr.GetDateTime(rdr.GetOrdinal("Fecha_Registro"))
                        });
                    }
                }
            }
            return Ok(lista);
        }

        // GET: api/Rotacion/buscar/fecha/{fecha} (yyyy-MM-dd)
        [HttpGet("buscar/fecha/{fecha}")]
        public IActionResult BuscarRotacionPorFecha(string fecha)
        {
            if (!DateTime.TryParse(fecha, out DateTime fechaParsed))
                return BadRequest("Formato de fecha inválido. Use yyyy-MM-dd");

            var lista = new List<RotacionDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("BuscarRotacionPorFecha", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaEntrega", fechaParsed.Date);
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new RotacionDto
                        {
                            ID_Rotacion = rdr.GetInt32(rdr.GetOrdinal("ID_Rotacion")),
                            ID_Producto = rdr.GetInt32(rdr.GetOrdinal("ID_Producto")),
                            Producto = rdr["Producto"].ToString() ?? string.Empty,
                            ID_Estudiante = rdr.GetInt32(rdr.GetOrdinal("ID_Estudiante")),
                            Estudiante = rdr["Estudiante"].ToString() ?? string.Empty,
                            ID_Tutor = rdr.GetInt32(rdr.GetOrdinal("ID_Tutor")),
                            Tutor = rdr["Tutor"].ToString() ?? string.Empty,
                            ID_Turno = rdr.GetInt32(rdr.GetOrdinal("ID_Turno")),
                            Turno = rdr["Turno"].ToString() ?? string.Empty,
                            Cantidad_Entregada = rdr.GetInt32(rdr.GetOrdinal("Cantidad_Entregada")),
                            Fecha_Entrega = rdr.GetDateTime(rdr.GetOrdinal("Fecha_Entrega")),
                            Fecha_Recepcion = rdr.IsDBNull(rdr.GetOrdinal("Fecha_Recepcion")) ? null : (DateTime?)rdr.GetDateTime(rdr.GetOrdinal("Fecha_Recepcion")),
                            Estado = rdr["Estado"].ToString() ?? string.Empty,
                            Observaciones = rdr["Observaciones"].ToString() ?? string.Empty,
                            Usuario_Registro = rdr["Usuario_Registro"].ToString() ?? string.Empty,
                            Fecha_Registro = rdr.GetDateTime(rdr.GetOrdinal("Fecha_Registro"))
                        });
                    }
                }
            }
            return Ok(lista);
        }
    }
}
