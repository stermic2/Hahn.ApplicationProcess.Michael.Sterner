using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.February2021.Web
{
    public partial class DemoDbContext : DbContext
    {
        public static string ConnectionString = string.Empty;

        public DemoDbContext(DbContextOptions<DemoDbContext> options, IHttpContextAccessor accessor) :
            base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");
        }
    }
}