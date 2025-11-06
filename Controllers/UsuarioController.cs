using ApiProyecto.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Usuario
        [HttpGet]
        public IActionResult MostrarUsuario()
        {
            var lista = new List<UsuarioDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (var con = new SqlConnection(cs))
                using (var cmd = new SqlCommand("MostrarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(new UsuarioDto
                            {
                                ID_Usuario = rdr.GetInt32(rdr.GetOrdinal("ID_Usuario")),
                                Nombre_Usuario = rdr["Nombre_Usuario"].ToString() ?? string.Empty,
                                Contraseña = rdr["Contraseña"].ToString() ?? string.Empty,
                                ID_Rol = rdr.GetInt32(rdr.GetOrdinal("ID_Rol")),
                                RolNombre = rdr["Rol"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener usuarios: {ex.Message}");
            }
        }

        // POST: api/Usuario
        [HttpPost]
        public IActionResult InsertarUsuario([FromBody] UsuarioDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (var con = new SqlConnection(cs))
                using (var cmd = new SqlCommand("InsertarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre_Usuario", dto.Nombre_Usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", dto.Contraseña);
                    cmd.Parameters.AddWithValue("@ID_Rol", dto.ID_Rol);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Usuario insertado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar usuario: {ex.Message}");
            }
        }

        // PUT: api/Usuario/{id}
        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] UsuarioDto dto)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (var con = new SqlConnection(cs))
                using (var cmd = new SqlCommand("ActualizarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Usuario", id);
                    cmd.Parameters.AddWithValue("@Nombre_Usuario", dto.Nombre_Usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", dto.Contraseña);
                    cmd.Parameters.AddWithValue("@ID_Rol", dto.ID_Rol);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Usuario actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar usuario: {ex.Message}");
            }
        }

        // DELETE: api/Usuario/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (var con = new SqlConnection(cs))
                using (var cmd = new SqlCommand("EliminarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Usuario", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return Ok("Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar usuario: {ex.Message}");
            }
        }

        // GET: api/Usuario/buscar/{nombre}
        [HttpGet("buscar/{nombre}")]
        public IActionResult BuscarUsuario(string nombre)
        {
            var lista = new List<UsuarioDto>();
            string cs = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (var con = new SqlConnection(cs))
                using (var cmd = new SqlCommand("BuscarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombre);
                    con.Open();

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(new UsuarioDto
                            {
                                ID_Usuario = rdr.GetInt32(rdr.GetOrdinal("ID_Usuario")),
                                Nombre_Usuario = rdr["NombreUsuario"].ToString() ?? string.Empty,
                                Contraseña = rdr["Contraseña"].ToString() ?? string.Empty,
                                ID_Rol = rdr.GetInt32(rdr.GetOrdinal("ID_Rol")),
                                RolNombre = rdr["Nombre_Rol"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar usuario: {ex.Message}");
            }
        }
    }
}
