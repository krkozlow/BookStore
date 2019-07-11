using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Book.Service.Domain
{
    public interface IBookRepository
    {
        Task<Book> Get(Guid id);

        Task Add(Book book);
    }
}
