using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Services.Infrastructure.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150); // null olamaz
            builder.Property(x => x.Stock).IsRequired(); // null olamaz
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)"); // null olamaz

            builder.HasOne(x => x.Category).WithMany(x => x.Books).HasForeignKey(x => x.CategoryId);

            builder.ToTable("Books");
        }
    }
}
