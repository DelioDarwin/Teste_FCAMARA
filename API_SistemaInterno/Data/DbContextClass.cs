using Microsoft.EntityFrameworkCore;
using API_SistemaInterno.Models;

namespace API_SistemaInterno.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
