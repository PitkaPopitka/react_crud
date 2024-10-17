using BookStore.Core.models;
using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Cfg
{
    public class BookCfg : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder) 
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(Book.MAX_TITLE_LENGTH)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.Price)
                .IsRequired();
        }
    }
}
