using AuthorAndBook.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBook.Infrastructure.Configrations
{
    public class BookConfigration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.ImageBook).IsRequired();
            builder.Property(b => b.ISBN).IsRequired();

            builder.HasOne(b => b.Author)        // Book has one Author
            .WithMany(a => a.Books)       // Author has many Books
            .HasForeignKey(b => b.AuthorId); // Foreign Key in Book table
        }
    }
}
