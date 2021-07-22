using Bookworm.BAL.Core.Book.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookworm.BAL.Core.Book.Interfaces
{
    public interface IAuthorManager
    {
        void AddAuthor(Author author);
    }
}
