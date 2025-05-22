using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Models.Rate;

public class BookRateConfig : IEntityTypeConfiguration<BookRate>
{
    public void Configure(EntityTypeBuilder<BookRate> builder)
    {

    }
}
