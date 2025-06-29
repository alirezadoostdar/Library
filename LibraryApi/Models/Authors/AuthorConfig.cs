using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Models.Authors;

public class AuthorConfig : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
        builder.Property(a => a.Family).HasMaxLength(50).IsRequired();

        builder.Property(a => a.LicenseNumber).IsRequired();
        builder.Property(a => a.Birthday).IsRequired();

        builder.OwnsOne(_ => _.ContactInfo, c =>
        {
            c.Property(_ => _.PhoneNumber).HasColumnName("PhoneNumber");
            c.Property(_ => _.Address).HasColumnName("Address");
        });
    }
}
