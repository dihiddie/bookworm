﻿using Bookworm.DAL.PostgreSQL.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookworm.DAL.PostgreSQL.EF.Configurations
{
    class BookReviewsConfiguration : IEntityTypeConfiguration<BookReviews>
    {
        public void Configure(EntityTypeBuilder<BookReviews> builder)
        {
            builder.ToTable("BookReviews", "bookworm");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().HasDefaultValueSql("gen_random_uuid()");
        }
    }
}
