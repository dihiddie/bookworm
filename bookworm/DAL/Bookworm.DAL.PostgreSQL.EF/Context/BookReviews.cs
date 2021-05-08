namespace Bookworm.DAL.PostgreSQL.EF.Context
{
    using System;

    public class BookReviews
    {
        public Guid BookId { get; set; }

        public Guid StatusId { get; set; }

        public string Review { get; set; }

        public DateTime ReviewDateTime { get; set; }
    }
}