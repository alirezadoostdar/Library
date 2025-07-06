using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Models.Invoices;

public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.MemberId).IsRequired();
        builder.Property(x => x.Sign).IsRequired();

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Invoice)
            .HasForeignKey(x => x.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);         
    }
}

public class InvoiceItemsConfig : IEntityTypeConfiguration<InvoiceItems>
{
    public void Configure(EntityTypeBuilder<InvoiceItems> builder)
    {
        builder.ToTable("InvoiceDetails");
        builder.HasKey(x =>x.Id);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.BookId).IsRequired();
    }
}
