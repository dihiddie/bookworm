using Bookworm.DAL.PostgreSQL.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookworm.DAL.PostgreSQL.EF.Configurations
{
    public class BookReadingDurationConfiguration : IEntityTypeConfiguration<BookReadingDuration>
    {
        public void Configure(EntityTypeBuilder<BookReadingDuration> builder)
        {
            builder.ToTable("BookReadingDuration", "bookworm");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("gen_random_uuid()");            
        }
    }
}
