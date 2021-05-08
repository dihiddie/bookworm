namespace Bookworm.DAL.PostgreSQL.EF.Context
{
    using Bookworm.DAL.PostgreSQL.EF.Configurations;

    using Microsoft.EntityFrameworkCore;

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
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
        }
    }
}
