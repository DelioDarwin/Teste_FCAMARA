using Microsoft.EntityFrameworkCore;
using API_SistemaExterno1.Models;

namespace API_SistemaExterno1.Data
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
