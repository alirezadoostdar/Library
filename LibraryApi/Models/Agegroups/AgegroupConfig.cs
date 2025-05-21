using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Models.Agegroups;

public class AgeGroupConfig : IEntityTypeConfiguration<AgeGroup>
{
    public void Configure(EntityTypeBuilder<AgeGroup> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(50);

    }
}
