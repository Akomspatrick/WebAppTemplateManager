using WebAppTemplateManager.Domain.Entities;
using WebAppTemplateManager.Domain.Utils;
using WebAppTemplateManager.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebAppTemplateManager.Infrastructure.Persistence
{
    public class WebAppTemplateManagerContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<ModelTypeGroup> ModelTypeGroups { get; private set; }
        public DbSet<ModelType> ModelTypes { get; private set; }




        public WebAppTemplateManagerContext(DbContextOptions<WebAppTemplateManagerContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;

            // Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var constr = GetConnectionstringName.GetConnectionStrName(Environment.MachineName);
            var conn = _configuration.GetConnectionString(constr);
            optionsBuilder.UseMySql(conn!, GeneralUtils.GetMySqlVersion());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebAppTemplateManagerContext).Assembly);

        }
    }
}
