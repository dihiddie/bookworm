namespace Bookworm.DAL.PostgreSQL.EF.Configurations
{
    using Bookworm.DAL.PostgreSQL.EF.Context;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookRatingConfiguration : IEntityTypeConfiguration<BookRating>
    {
        public void Configure(EntityTypeBuilder<BookRating> builder)
        {
            builder.ToTable("BookRating", "bookworm");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("gen_random_uuid()");
            builder.HasIndex(e => new { e.BookId, e.RatingId }).IsUnique().HasDatabaseName("AK_BookRating_BookId_RatingId");
        }
    }
}
