using DocumentVersionManager.Domain.Entities;
using DocumentVersionManager.Domain.Utils;
using DocumentVersionManager.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DocumentVersionManager.Infrastructure.Persistence
{
    public class DocumentVersionManagerContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<ModelTypeGroup> ModelTypeGroups { get; private set; }
        public DbSet<ModelType> ModelTypes { get; private set; }
        public DbSet<Model> Models { get; private set; }
        public DbSet<ModelVersion> ModelVersions { get; private set; }
        public DbSet<Document> Documents { get; private set; }
        public DbSet<DocumentType> DocumentTypes { get; private set; }
        public DbSet<DocumentDocumentType> DocumentDocumentTypes { get; private set; }
        public DbSet<TestPoint> TestPoints { get; private set; }
        public DbSet<ShellMaterial> ShellMaterials { get; private set; }
        public DbSet<Product> Products { get; private set; }
        public DbSet<DocumentBasePath> DocumentBasePaths { get; private set; }



        public DocumentVersionManagerContext(DbContextOptions<DocumentVersionManagerContext> options, IConfiguration configuration) : base(options)
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentVersionManagerContext).Assembly);

        }
    }
}
