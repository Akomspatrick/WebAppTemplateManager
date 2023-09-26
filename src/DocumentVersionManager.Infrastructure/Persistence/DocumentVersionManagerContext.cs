using DocumentVersionManager.Infrastructure.Persistence.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence
{
    public class DocumentVersionManagerContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Model> ProductModel { get; private set; }
        public DbSet<ModelType> ModelType { get; private set; }
        public DbSet<CapacityDocument> CapacityDocument { get; private set; }
        public DbSet<CapacitySpecification> CapacitySpecification { get; private set; }

        public DocumentVersionManagerContext(DbContextOptions<DocumentVersionManagerContext> options, IConfiguration configuration) : base(options) 
        {
            _configuration =configuration;
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = _configuration.GetConnectionString("constr");
            optionsBuilder.UseMySQL(conn!);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ModelType>(entity =>
            {
                entity.HasKey(e => e.ModelName);
               
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.ModelName);
                entity.Property(e => e.ModelTypeName).IsRequired();
            });

            modelBuilder.Entity<CapacityDocument>(entity =>
            {
                entity.HasKey(e => e.Capacity);
                // entity.Property(e => e.).IsRequired();
             //   entity.HasOne(d => d.ModelName);
                 // .WithMany(p => p.Books);
            });

            modelBuilder.Entity<CapacitySpecification>(entity =>
            {
                entity.HasKey(e => e.Capacity);
               // entity.Property(e => e.).IsRequired();
              //  entity.HasOne(d => d.ModelName)
                 // .WithMany(p => p.Books);
            });
        }
    }
}
