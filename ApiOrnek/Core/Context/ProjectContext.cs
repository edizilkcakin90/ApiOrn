using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options)
            : base(options)
        {
        }

        public ProjectContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=DbApiOrnek;Trusted_Connection=True"
                );
        }

        public DbSet<User> Users { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProjectContext>();
        }
    }
}
