namespace Bookworm.DAL.PostgreSQL.EF.Context
{
    using System;

    public class BookRating
    {
        public Guid BookId { get; set; }

        public Guid RatingId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
