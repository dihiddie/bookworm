namespace Bookworm.DAL.PostgreSQL.EF.Context
{
    using System;

    public class Book
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
