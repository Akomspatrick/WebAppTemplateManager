using DocumentVersionManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DocumentVersionManager.Infrastructure.Persistence
{
    public class DocumentVersionManagerContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<ModelType> ModelTypes { get; private set; }
        public DbSet<Model> Models { get; private set; }
        public DbSet<ModelVersion> ModelVersions { get; private set; }
        public DbSet<Document> Documents { get; private set; }
        public DbSet<DocumentType> DocumentTypes { get; private set; }
        public DbSet<DocumentDocumentType> DocumentDocumentTypes { get; private set; }
        public DbSet<Specification> Specifications { get; private set; }
        public DbSet<TestPoint> TestPoints { get; private set; }
        public DbSet<ShellMaterial> ShellMaterials { get; private set; }
        public DbSet<Product> Products { get; private set; }
        public DbSet<DocumentBasePath> DocumentBasePaths { get; private set; }
        public DbSet<TestFlowType> TestFlowTypes { get; private set; }


        public DocumentVersionManagerContext(DbContextOptions<DocumentVersionManagerContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            // Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = _configuration.GetConnectionString(Domain.Constants.FixedValues.DBConnectionStringName);

            optionsBuilder.UseMySql(conn!, new MySqlServerVersion(new Version(8, 0)));


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // instead of calling the configure method of each entity configuration file we can use the methos below
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentVersionManagerContext).Assembly);


        }
    }
}
