using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Models.Categories;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(x => x.AgeGroup)
            .WithMany()
            .HasForeignKey(x => x.AgeGroupId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
