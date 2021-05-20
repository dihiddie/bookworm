namespace Bookworm.DAL.PostgreSQL.EF.Context
{
    using System;

    public class BookStatus
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }

        public Guid StatusId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Status Status { get; set; }

        public DateTime StatusSettingDateTime { get; set; }
    }
}
