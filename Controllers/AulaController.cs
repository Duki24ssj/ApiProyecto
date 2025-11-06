using ApiProyecto.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AulaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AulaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Aula
        [HttpGet]
        public IActionResult MostrarAula()
        {
            var lista = new List<AulaDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("MostrarAula", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new AulaDto
                        {
                            ID_Aula = rdr.GetInt32(rdr.GetOrdinal("ID_Aula")),
                            Nombre_Aula = rdr["Nombre_Aula"].ToString() ?? string.Empty,
                            Nombre_Tutor = rdr["Nombre_Tutor"].ToString() ?? string.Empty
                        });
                    }
                }
            }
            return Ok(lista);
        }

        // POST: api/Aula
        [HttpPost]
        public IActionResult InsertarAula([FromBody] AulaDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("InsertarAula", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", dto.Nombre_Aula);
                cmd.Parameters.AddWithValue("@ID_Tutor", dto.ID_Tutor);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Aula insertada correctamente");
        }

        // PUT: api/Aula/{id}
        [HttpPut("{id}")]
        public IActionResult ActualizarAula(int id, [FromBody] AulaDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("ActualizarAula", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Aula", id);
                cmd.Parameters.AddWithValue("@Nombre", dto.Nombre_Aula);
                cmd.Parameters.AddWithValue("@ID_Tutor", dto.ID_Tutor );
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Aula actualizada correctamente");
        }

        // DELETE: api/Aula/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarAula(int id)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("EliminarAula", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Aula", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Aula eliminada correctamente");
        }

        // GET: api/Aula/buscar/{nombre}
        [HttpGet("buscar/{nombre}")]
        public IActionResult BuscarAula(string nombre)
        {
            var lista = new List<AulaDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("BuscarAula", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreAula", nombre);
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new AulaDto
                        {
                            ID_Aula = rdr.GetInt32(rdr.GetOrdinal("ID_Aula")),
                            Nombre_Aula = rdr["NombreAula"].ToString() ?? string.Empty,
                            Nombre_Tutor = rdr["NombreTutor"].ToString() ?? string.Empty
                        });
                    }
                }
            }
            return Ok(lista);
        }
    }
}
