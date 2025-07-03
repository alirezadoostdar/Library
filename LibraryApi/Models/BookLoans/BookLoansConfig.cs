using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Models.BookLoans;

public class BookLoansConfig : IEntityTypeConfiguration<BookLoan>
{
    public void Configure(EntityTypeBuilder<BookLoan> builder)
    {
        builder.ToTable("BookLoans");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.RegisterDate).IsRequired();

        //builder.HasOne(x => x.Member)
        //    .WithMany()
        //    .HasForeignKey(x => x.MemberId);
    }
}
