using ApiProyecto.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroSalidaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RegistroSalidaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/RegistroSalida
        [HttpGet]
        public IActionResult MostrarSalida()
        {
            var lista = new List<RegistroSalidaDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");

            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("MostrarSalida", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new RegistroSalidaDto
                        {
                            ID_Registro_Salida = rdr.GetInt32(rdr.GetOrdinal("ID_Registro_Salida")),
                            ID_Producto = rdr.GetInt32(rdr.GetOrdinal("ID_Producto")),
                            ID_Tutor = rdr.GetInt32(rdr.GetOrdinal("ID_Tutor")),
                            ID_Aula = rdr.GetInt32(rdr.GetOrdinal("ID_Aula")),
                            ID_Turno = rdr.GetInt32(rdr.GetOrdinal("ID_Turno")),
                            Producto = rdr["Producto"].ToString() ?? string.Empty,
                            Tutor = rdr["Tutor"].ToString() ?? string.Empty,
                            Aula = rdr["Aula"].ToString() ?? string.Empty,
                            Turno = rdr["Turno"].ToString() ?? string.Empty,
                            Cantidad_Entregada = rdr.GetInt32(rdr.GetOrdinal("Cantidad_Entregada")),
                            Fecha_Salida = rdr.IsDBNull(rdr.GetOrdinal("Fecha_Salida")) ? null : (DateTime?)rdr.GetDateTime(rdr.GetOrdinal("Fecha_Salida"))
                        });
                    }
                }
            }

            return Ok(lista);
        }

        // POST: api/RegistroSalida
        [HttpPost]
        public IActionResult InsertarRegistroSalida([FromBody] RegistroSalidaDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("InsertarRegistroSalida", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Producto", dto.ID_Producto);
                cmd.Parameters.AddWithValue("@ID_Tutor", dto.ID_Tutor);
                cmd.Parameters.AddWithValue("@ID_Aula", dto.ID_Aula);
                cmd.Parameters.AddWithValue("@ID_Turno", dto.ID_Turno);
                cmd.Parameters.AddWithValue("@Cantidad_Entregada", dto.Cantidad_Entregada);
                cmd.Parameters.AddWithValue("@Fecha_Salida", dto.Fecha_Salida ?? (object)DBNull.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Registro de salida insertado correctamente");
        }

        // PUT: api/RegistroSalida/{id}
        [HttpPut("{id}")]
        public IActionResult ActualizarRegistroSalida(int id, [FromBody] RegistroSalidaDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("ActualizarRegistroSalida", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Registro_Salida", id);
                cmd.Parameters.AddWithValue("@ID_Producto", dto.ID_Producto);
                cmd.Parameters.AddWithValue("@ID_Tutor", dto.ID_Tutor);
                cmd.Parameters.AddWithValue("@ID_Aula", dto.ID_Aula);
                cmd.Parameters.AddWithValue("@ID_Turno", dto.ID_Turno);
                cmd.Parameters.AddWithValue("@Cantidad_Entregada", dto.Cantidad_Entregada);
                cmd.Parameters.AddWithValue("@Fecha_Salida", dto.Fecha_Salida ?? (object)DBNull.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Registro de salida actualizado correctamente");
        }

        // DELETE: api/RegistroSalida/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarRegistroSalida(int id)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("EliminarRegistroSalida", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Registro_Salida", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Registro de salida eliminado correctamente");
        }

        // GET: api/RegistroSalida/buscar/nombre/{nombre}
        [HttpGet("buscar/nombre/{nombre}")]
        public IActionResult BuscarRegistroSalidaPorNombre(string nombre)
        {
            var lista = new List<RegistroSalidaDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("BuscarRegistroSalidaPorNombre", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProducto", nombre);
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new RegistroSalidaDto
                        {
                            ID_Registro_Salida = rdr.GetInt32(rdr.GetOrdinal("ID_Registro_Salida")),
                            Producto = rdr["NombreProducto"].ToString() ?? string.Empty,
                            Tutor = rdr["NombreTutor"].ToString() ?? string.Empty,
                            Aula = rdr["NombreAula"].ToString() ?? string.Empty,
                            Turno = rdr["NombreTurno"].ToString() ?? string.Empty,
                            Cantidad_Entregada = rdr.GetInt32(rdr.GetOrdinal("Cantidad_Entregada")),
                            Fecha_Salida = rdr.IsDBNull(rdr.GetOrdinal("Fecha_Salida")) ? null : (DateTime?)rdr.GetDateTime(rdr.GetOrdinal("Fecha_Salida"))
                        });
                    }
                }
            }
            return Ok(lista);
        }

        // GET: api/RegistroSalida/buscar/fecha/{fecha}  (yyyy-MM-dd)
        [HttpGet("buscar/fecha/{fecha}")]
        public IActionResult BuscarRegistroSalidaPorFecha(string fecha)
        {
            if (!DateTime.TryParse(fecha, out DateTime fechaParsed))
                return BadRequest("Formato de fecha inválido. Use yyyy-MM-dd");

            var lista = new List<RegistroSalidaDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("BuscarRegistroSalidaPorFecha", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha_Salida", fechaParsed.Date);
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new RegistroSalidaDto
                        {
                            ID_Registro_Salida = rdr.GetInt32(rdr.GetOrdinal("ID_Registro_Salida")),
                            Producto = rdr["NombreProducto"].ToString() ?? string.Empty,
                            Tutor = rdr["NombreTutor"].ToString() ?? string.Empty,
                            Aula = rdr["NombreAula"].ToString() ?? string.Empty,
                            Turno = rdr["NombreTurno"].ToString() ?? string.Empty,
                            Cantidad_Entregada = rdr.GetInt32(rdr.GetOrdinal("Cantidad_Entregada")),
                            Fecha_Salida = rdr.IsDBNull(rdr.GetOrdinal("Fecha_Salida")) ? null : (DateTime?)rdr.GetDateTime(rdr.GetOrdinal("Fecha_Salida"))
                        });
                    }
                }
            }
            return Ok(lista);
        }
    }
}
