using Microsoft.Data.SqlClient;

namespace ApiProyecto.Data
{
    public class ConexionBD
    {
      
            private readonly IConfiguration _configuration;

            public ConexionBD(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string GetConnectionString()
            {
                return _configuration.GetConnectionString("DefaultConnection");
            }

            public SqlConnection GetSqlConnection()
            {
                return new SqlConnection(GetConnectionString());
            }
    }
}

