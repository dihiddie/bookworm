﻿namespace Bookworm.DAL.PostgreSQL.EF.Configurations
{
    using Bookworm.DAL.PostgreSQL.EF.Context;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status", "bookworm");
            builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        }
    }
}
