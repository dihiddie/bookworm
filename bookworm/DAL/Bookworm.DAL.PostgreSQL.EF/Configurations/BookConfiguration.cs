namespace Bookworm.DAL.PostgreSQL.EF.Configurations
{
    using Bookworm.DAL.PostgreSQL.EF.Context;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book", "bookworm");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(512);
        }
    }
}
