using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Models.Agegroups;

public class AgegroupConfig : IEntityTypeConfiguration<Agegroup>
{
    public void Configure(EntityTypeBuilder<Agegroup> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(50);

    }
}
