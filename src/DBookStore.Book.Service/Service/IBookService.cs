using DBookStore.Book.Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Book.Service.Service
{
    public interface IBookService
    {
        Task AddReview(Guid bookId, Review review);
    }
}
