using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBookStore.Book.Service.Domain;

namespace DBookStore.Book.Service.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task AddReview(Guid bookId, Review review)
        {
            Domain.Book book = await _repository.Get(bookId);
            if (book.Reviews == null)
            {
                book.Reviews = new List<Review>();
            }
            book.Reviews.Add(review);

            await _repository.Update(book);
        }
    }
}
