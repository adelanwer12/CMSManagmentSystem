using DataService.ModelsConfigurations;
using Microsoft.EntityFrameworkCore;
using ModelsServices.MainDb;

namespace DataService.DataBaseContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<address> addresses { get; set; }
        public DbSet<UserFullData> userFullData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AddressConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserFullDataConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}