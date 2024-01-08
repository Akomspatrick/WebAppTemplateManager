using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ModelTypeGroupConfig : IEntityTypeConfiguration<ModelTypeGroup>
    {
        public void Configure(EntityTypeBuilder<ModelTypeGroup> entity)
        {
        }
    }
}