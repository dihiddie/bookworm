using System;

namespace Bookworm.DAL.PostgreSQL.EF.Context
{
    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
