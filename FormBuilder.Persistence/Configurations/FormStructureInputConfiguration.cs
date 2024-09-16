using FormBuilder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Persistence.Configurations;

public class FormStructureInputConfiguration : IEntityTypeConfiguration<FormStructureInputEntity>
{
    public void Configure(EntityTypeBuilder<FormStructureInputEntity> builder)
    {
        builder.HasKey(x => new { x.FormStructureId, x.InputId });
    }
}