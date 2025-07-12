using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infarstructure.Persistence.FluentApiConfig;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(b  => b.Id);

        builder.Property(b => b.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(b => b.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(b => b.CategoryId)
            .IsRequired();
    }
}
