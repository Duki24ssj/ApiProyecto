using ApiProyecto.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiProyecto.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class TutorController : ControllerBase
        {
            private readonly IConfiguration _configuration;

            public TutorController(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            [HttpGet]
            public IActionResult MostrarTutor()
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                List<TutorDto> lista = new();

                using (SqlConnection con = new(connectionString))
                {
                    using (SqlCommand cmd = new("MostrarTutor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            lista.Add(new TutorDto
                            {
                                IdTutor = Convert.ToInt32(dr["IdTutor"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString()
                            });
                        }
                    }
                }
                return Ok(lista);
            }

            [HttpGet("buscar/{nombre}")]
            public IActionResult BuscarTutor(string nombre)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                List<TutorDto> lista = new();

                using (SqlConnection con = new(connectionString))
                {
                    using (SqlCommand cmd = new("BuscarTutor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            lista.Add(new TutorDto
                            {
                                IdTutor = Convert.ToInt32(dr["IdTutor"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString()
                            });
                        }
                    }
                }
                return Ok(lista);
            }

            [HttpPost]
            public IActionResult InsertarTutor([FromBody] TutorDto tutor)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new(connectionString))
                {
                    using (SqlCommand cmd = new("InsertarTutor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", tutor.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", tutor.Apellido);
                        cmd.Parameters.AddWithValue("@Telefono", tutor.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", tutor.Correo);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("Tutor insertado correctamente");
            }

            [HttpPut("{id}")]
            public IActionResult ActualizarTutor(int id, [FromBody] TutorDto tutor)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new(connectionString))
                {
                    using (SqlCommand cmd = new("ActualizarTutor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdTutor", id);
                        cmd.Parameters.AddWithValue("@Nombre", tutor.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", tutor.Apellido);
                        cmd.Parameters.AddWithValue("@Telefono", tutor.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", tutor.Correo);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("Tutor actualizado correctamente");
            }

            [HttpDelete("{id}")]
            public IActionResult EliminarTutor(int id)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new(connectionString))
                {
                    using (SqlCommand cmd = new("EliminarTutor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdTutor", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("Tutor eliminado correctamente");
            }
        }
    }

