using FormBuilder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Persistence.Configurations;

public class InputConfiguration : IEntityTypeConfiguration<InputEntity>
{
    public void Configure(EntityTypeBuilder<InputEntity> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.DataType)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.Required)
            .IsRequired();
    }
}