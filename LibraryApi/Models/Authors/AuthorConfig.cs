﻿using Microsoft.EntityFrameworkCore;
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

        builder.Property(a => a.ContactInfo.Address).HasMaxLength(200);
        builder.Property(a => a.ContactInfo.PhoneNumber).HasMaxLength(50).IsRequired();
        builder.Property(a => a.LicenseNumber).IsRequired();
        builder.Property(a => a.Birthday).IsRequired();
    }
}
