using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBookStore.Book.Service.Domain;
using DBookStore.Common.DbProvider;

namespace DBookStore.Book.Service.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Domain.Book> _books;

        public BookRepository(IMongoDbProvider<Domain.Book> dbProvider)
        {
            _books = dbProvider.GetConnection();
        }

        public async Task<Domain.Book> Get(Guid id)
        {
            var result = await _books.FindAsync(book => book.Id.Equals(id));
            return await result.FirstOrDefaultAsync();
        }

        public async Task Add(Domain.Book book)
        {
            await _books.InsertOneAsync(book);
        }

        public async Task Update(Domain.Book book)
        {
            await _books.ReplaceOneAsync(x => x.Id == book.Id, book);
        }
    }
}
