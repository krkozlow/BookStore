using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Client.Api.Repository
{
    public interface IBookRepository
    {
        Task<BookDto> Get(Guid id);
        Task Add(BookDto book);
        Task Update(BookDto book);
    }
}
