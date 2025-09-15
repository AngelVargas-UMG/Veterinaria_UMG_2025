using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Models;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Data
{
    // Contexto de la base de datos para Entity Framework Core
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<EstadoSalud> EstadosSalud { get; set; }
        public DbSet<HistorialMedico> HistorialesMedicos { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<MotivosVisita> MotivosVisitas { get; set; }
        public DbSet<ProcedimientoMedico> ProcedimientosMedicos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Visita> Visitas { get; set; }
        public DbSet<VisitaProcedimiento> VisitaProcedimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración adicional de modelos si es necesario
        }
    }
}
