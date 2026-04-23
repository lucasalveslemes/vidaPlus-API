using Microsoft.EntityFrameworkCore;
using VidaPlus.Domain.Entities;

namespace VidaPlus.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
