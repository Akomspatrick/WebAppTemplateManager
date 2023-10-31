using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DocumentVersionManager.Infrastructure.Persistence
{
    public class DocumentVersionManagerContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<ModelTypes> ModelType { get; private set; }
        public DbSet<Model> Models { get; private set; }
        public DbSet<ModelVersion> ModelVersion { get; private set; }
        public DbSet<Document> Document { get; private set; }
        public DbSet<DocumentType> DocumentType { get; private set; }
        public DbSet<DocumentDocumentType> DocumentDocumentType { get; private set; }
        public DbSet<CapacitySpecification> CapacitySpecification { get; private set; }
        public DbSet<CapacityTestPoint> CapacityTestPoint { get; private set; }
        public DbSet<ShellMaterial> ShellMaterial { get; private set; } 


        public DbSet<HigherModel> HigherModel { get; private set; }

    

        //public DbSet<CapacityDocument> CapacityDocument { get; private set; }
        //public DbSet<CapacitySpecification> CapacitySpecification { get; private set; }

        public DocumentVersionManagerContext(DbContextOptions<DocumentVersionManagerContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            // Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = _configuration.GetConnectionString(Domain.Constants.FixedValues.DBConnectionStringName);
            optionsBuilder.UseMySQL(conn!);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // instead of calling the configure method of each entity configuration file we can use the methos below
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentVersionManagerContext).Assembly);

            //modelBuilder.Entity<Model>(entity =>
            //{
            //    entity.HasKey(e => e.ModelName);
            //    entity.Property(e => e.ModelTypeName).IsRequired();
            //});

            //modelBuilder.Entity<CapacityDocument>(entity =>
            //{
            //    entity.HasKey(e => e.Capacity);
            //    // entity.Property(e => e.).IsRequired();
            // //   entity.HasOne(d => d.ModelName);
            //     // .WithMany(p => p.Books);
            //});

            //modelBuilder.Entity<CapacitySpecification>(entity =>
            //{
            //    entity.HasKey(e => e.Capacity);
            //   // entity.Property(e => e.).IsRequired();
            //  //  entity.HasOne(d => d.ModelName)
            //     // .WithMany(p => p.Books);
            //});
        }
    }
}
