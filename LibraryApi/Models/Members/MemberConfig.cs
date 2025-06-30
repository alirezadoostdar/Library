using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Models.Members;

public class MemberConfig : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Family).IsRequired().HasMaxLength(50);
        builder.Property(x => x.MembershipNumber).IsRequired();
        builder.Property(x => x.MembershipDate).IsRequired();
        builder.OwnsOne(x => x.ContactInfo, c =>
        {
            c.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .IsRequired()
                .HasMaxLength(11);

            c.Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(200);
        });
    }
}
