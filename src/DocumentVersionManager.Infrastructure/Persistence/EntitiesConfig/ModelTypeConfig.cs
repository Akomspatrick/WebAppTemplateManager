using DocumentVersionManager.Infrastructure.Persistence.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ModelTypeConfig : IEntityTypeConfiguration<ModelType>
    {
        public void Configure(EntityTypeBuilder<ModelType> entity)
        {
            entity.HasKey(e => e.ModelTypeName);
            entity.Property(e => e.ModelTypeName).IsRequired().HasMaxLength(128);

            entity.HasData(new ModelType() { ModelTypeName = "FIRSTMODELTYPE" },
                           new ModelType() { ModelTypeName = "SECONDMODELTYPE" },
                           new ModelType() { ModelTypeName = "THIRDMODELTYPE" });
        }
    }
}
