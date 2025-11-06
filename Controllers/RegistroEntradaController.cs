using ApiProyecto.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroEntradaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RegistroEntradaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/RegistroEntrada
        [HttpGet]
        public IActionResult MostrarEntrada()
        {
            var lista = new List<RegistroEntradaDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");

            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("MostrarEntrada", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new RegistroEntradaDto
                        {
                            ID_Registro_Entrada = rdr.GetInt32(rdr.GetOrdinal("ID_Registro_Entrada")),
                            ID_Producto = rdr.GetInt32(rdr.GetOrdinal("ID_Producto")),
                            Producto = rdr["Producto"].ToString() ?? string.Empty,
                            Cantidad_Disponible = rdr.GetInt32(rdr.GetOrdinal("Cantidad_Disponible")),
                            Umbral_Minimo = rdr.GetInt32(rdr.GetOrdinal("Umbral_Minimo")),
                            Fecha_Ingreso = rdr.GetDateTime(rdr.GetOrdinal("Fecha_Ingreso"))
                        });
                    }
                }
            }

            return Ok(lista);
        }

        // POST: api/RegistroEntrada
        [HttpPost]
        public IActionResult InsertarRegistroEntrada([FromBody] RegistroEntradaDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("InsertarRegistroEntrada", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Producto", dto.ID_Producto);
                cmd.Parameters.AddWithValue("@Cantidad_Disponible", dto.Cantidad_Disponible);
                cmd.Parameters.AddWithValue("@Umbral_Minimo", dto.Umbral_Minimo);
                cmd.Parameters.AddWithValue("@Fecha_Ingreso", dto.Fecha_Ingreso.Date);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Registro de entrada insertado correctamente");
        }

        // PUT: api/RegistroEntrada/{id}
        [HttpPut("{id}")]
        public IActionResult ActualizarRegistroEntrada(int id, [FromBody] RegistroEntradaDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("ActualizarRegistroEntrada", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Registro_Entrada", id);
                cmd.Parameters.AddWithValue("@ID_Producto", dto.ID_Producto);
                cmd.Parameters.AddWithValue("@Cantidad_Disponible", dto.Cantidad_Disponible);
                cmd.Parameters.AddWithValue("@Umbral_Minimo", dto.Umbral_Minimo);
                cmd.Parameters.AddWithValue("@Fecha_Ingreso", dto.Fecha_Ingreso.Date);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Registro de entrada actualizado correctamente");
        }

        // DELETE: api/RegistroEntrada/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarRegistroEntrada(int id)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("EliminarRegistroEntrada", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Registro_Entrada", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Registro de entrada eliminado correctamente");
        }

        // GET: api/RegistroEntrada/buscar/nombre/{nombre}
        [HttpGet("buscar/nombre/{nombre}")]
        public IActionResult BuscarRegistroEntradaPorNombre(string nombre)
        {
            var lista = new List<RegistroEntradaDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("BuscarRegistroEntradaPorNombre", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreProducto", nombre);
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new RegistroEntradaDto
                        {
                            ID_Registro_Entrada = rdr.GetInt32(rdr.GetOrdinal("ID_Registro_Entrada")),
                            Producto = rdr["NombreProducto"].ToString() ?? string.Empty,
                            Cantidad_Disponible = rdr.GetInt32(rdr.GetOrdinal("Cantidad_Disponible")),
                            Umbral_Minimo = rdr.GetInt32(rdr.GetOrdinal("Umbral_Minimo")),
                            Fecha_Ingreso = rdr.GetDateTime(rdr.GetOrdinal("Fecha_Ingreso"))
                        });
                    }
                }
            }
            return Ok(lista);
        }

        // GET: api/RegistroEntrada/buscar/fecha/{fecha}  (fecha en formato yyyy-MM-dd)
        [HttpGet("buscar/fecha/{fecha}")]
        public IActionResult BuscarRegistroEntradaPorFecha(string fecha)
        {
            if (!DateTime.TryParse(fecha, out DateTime fechaParsed))
                return BadRequest("Formato de fecha inválido. Use yyyy-MM-dd");

            var lista = new List<RegistroEntradaDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("BuscarRegistroEntradaPorFecha", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha_Entrada", fechaParsed.Date);
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new RegistroEntradaDto
                        {
                            ID_Registro_Entrada = rdr.GetInt32(rdr.GetOrdinal("ID_Registro_Entrada")),
                            Producto = rdr["NombreProducto"].ToString() ?? string.Empty,
                            Cantidad_Disponible = rdr.GetInt32(rdr.GetOrdinal("Cantidad_Disponible")),
                            Umbral_Minimo = rdr.GetInt32(rdr.GetOrdinal("Umbral_Minimo")),
                            Fecha_Ingreso = rdr.GetDateTime(rdr.GetOrdinal("Fecha_Ingreso"))
                        });
                    }
                }
            }
            return Ok(lista);
        }
    }
}
