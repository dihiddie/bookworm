using System;

namespace Bookworm.DAL.PostgreSQL.EF.Context
{
    public class Status
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }
    }
}
