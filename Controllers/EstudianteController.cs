using ApiProyecto.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EstudianteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Estudiante
        [HttpGet]
        public IActionResult MostrarEstudiante()
        {
            var lista = new List<EstudianteDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("MostrarEstudiante", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new EstudianteDto
                        {
                            ID_Estudiante = rdr.GetInt32(rdr.GetOrdinal("ID_Estudiante")),
                            Nombre = rdr["Nombre"].ToString() ?? string.Empty,
                            Apellido = rdr["Apellido"].ToString() ?? string.Empty,
                            Grado = rdr["Grado"].ToString() ?? string.Empty,
                            Grupo = rdr["Grupo"].ToString() ?? string.Empty,
                            Usuario_Registro = rdr["Usuario_Registro"].ToString() ?? string.Empty,
                            Fecha_Registro = rdr.GetDateTime(rdr.GetOrdinal("Fecha_Registro"))
                        });
                    }
                }
            }
            return Ok(lista);
        }

        // POST: api/Estudiante
        [HttpPost]
        public IActionResult InsertarEstudiante([FromBody] EstudianteDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("InsertarEstudiante", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", dto.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", dto.Apellido);
                cmd.Parameters.AddWithValue("@Grado", dto.Grado);
                cmd.Parameters.AddWithValue("@Grupo", dto.Grupo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Estudiante insertado correctamente");
        }

        // PUT: api/Estudiante/{id}
        [HttpPut("{id}")]
        public IActionResult ActualizarEstudiante(int id, [FromBody] EstudianteDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("ActualizarEstudiante", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Estudiante", id);
                cmd.Parameters.AddWithValue("@Nombre", dto.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", dto.Apellido);
                cmd.Parameters.AddWithValue("@Grado", dto.Grado);
                cmd.Parameters.AddWithValue("@Grupo", dto.Grupo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Estudiante actualizado correctamente");
        }

        // DELETE: api/Estudiante/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarEstudiante(int id)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("EliminarEstudiante", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Estudiante", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return Ok("Estudiante eliminado correctamente");
        }

        // GET: api/Estudiante/buscar/{nombre}
        [HttpGet("buscar/{nombre}")]
        public IActionResult BuscarEstudiantePorNombre(string nombre)
        {
            var lista = new List<EstudianteDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("BuscarEstudiantePorNombre", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new EstudianteDto
                        {
                            ID_Estudiante = rdr.GetInt32(rdr.GetOrdinal("ID_Estudiante")),
                            Nombre = rdr["Nombre"].ToString() ?? string.Empty,
                            Apellido = rdr["Apellido"].ToString() ?? string.Empty,
                            Grado = rdr["Grado"].ToString() ?? string.Empty,
                            Grupo = rdr["Grupo"].ToString() ?? string.Empty,
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
