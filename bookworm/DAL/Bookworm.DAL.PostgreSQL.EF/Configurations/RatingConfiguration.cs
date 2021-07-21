namespace Bookworm.DAL.PostgreSQL.EF.Configurations
{
    using Bookworm.DAL.PostgreSQL.EF.Context;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Rating", "bookworm");
            builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        }
    }
}
