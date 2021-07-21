namespace Bookworm.DAL.PostgreSQL.EF.Context
{
    using Bookworm.BAL.Core.Attributes;
    using Bookworm.BAL.Core.Enums;
    using Bookworm.BAL.Core.Extensions;
    using Bookworm.DAL.PostgreSQL.EF.Configurations;

    using Microsoft.EntityFrameworkCore;
    using System;

    public class BookwormContext : DbContext
    {
        public BookwormContext() { }

        public BookwormContext(DbContextOptions<BookwormContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }

        public virtual DbSet<Status> Status { get; set; }

        public virtual DbSet<Rating> Rating { get; set; }

        public virtual DbSet<Book> Book { get; set; }

        public virtual DbSet<BookRating> BookRating { get; set; }

        public virtual DbSet<BookStatus> BookStatus { get; set; }

        public virtual DbSet<BookReadingDuration> BookReadingDuration { get; set; }

        public virtual DbSet<BookReviews> BookReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("bookworm");
            modelBuilder.HasPostgresExtension("pgcrypto");
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookRatingConfiguration());
            modelBuilder.ApplyConfiguration(new BookReadingDurationConfiguration());
            modelBuilder.ApplyConfiguration(new BookReviewsConfiguration());
            modelBuilder.ApplyConfiguration(new BookStatusConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            foreach (StatusEnum statusEnum in Enum.GetValues(typeof(StatusEnum)))
            {
                var color = statusEnum.GetAttribute<ColorAttribute>();
                modelBuilder.Entity<Status>().HasData(new Status { Id = Guid.NewGuid(), Name = statusEnum.ToString(), Color = color.Color.ToString()});
            }

            foreach (RatingEnum ratingEnum in Enum.GetValues(typeof(RatingEnum)))
            {
                var rating = ratingEnum.GetAttribute<DisplayNameAttribute>();
                modelBuilder.Entity<Rating>().HasData(new Rating { Id = Guid.NewGuid(), Number = int.Parse(rating.Name) });               
            }
        }
    }
}
