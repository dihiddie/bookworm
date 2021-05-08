using System;

namespace Bookworm.DAL.PostgreSQL.EF.Context
{
    public class Rating
    {
        public Guid Id { get; set; }

        public int Number { get; set; }
    }
}
