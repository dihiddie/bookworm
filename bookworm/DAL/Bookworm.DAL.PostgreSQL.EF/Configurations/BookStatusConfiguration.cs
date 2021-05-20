namespace Bookworm.DAL.PostgreSQL.EF.Configurations
{
    using Bookworm.DAL.PostgreSQL.EF.Context;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookStatusConfiguration : IEntityTypeConfiguration<BookStatus>
    {
        public void Configure(EntityTypeBuilder<BookStatus> builder)
        {
            builder.ToTable("BookStatus", "bookworm");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("gen_random_uuid()");
            builder.HasIndex(e => new { e.BookId, e.StatusId }).IsUnique().HasDatabaseName("AK_BookStatus_BookId_StatusId");
        }
    }
}
