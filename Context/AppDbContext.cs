using Microsoft.EntityFrameworkCore;
using ApiProyecto.Models;

namespace ApiProyecto.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
        public virtual DbSet<Auditoria_General> Auditoria_General { get; set; }
        public virtual DbSet<Aula> Aula { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Registro_Entrada> Registro_Entrada { get; set; }
        public virtual DbSet<Registro_Salida> Registro_Salida { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Rotacion> Rotacion { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
        public virtual DbSet<Tutor> Tutor{ get; set; }
        public virtual DbSet<Usuario> Usuario{ get; set; }

    }
}
