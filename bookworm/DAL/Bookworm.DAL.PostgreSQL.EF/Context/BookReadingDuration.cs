using System;

namespace Bookworm.DAL.PostgreSQL.EF.Context
{
    public class BookReadingDuration
    {
        public Guid BookId { get; set; }

        public virtual Book Book { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
