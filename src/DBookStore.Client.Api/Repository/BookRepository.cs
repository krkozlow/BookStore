using DBookStore.Common.DbProvider;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Client.Api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<BookDto> _books;

        public BookRepository(IMongoDbProvider<BookDto> dbProvider)
        {
            _books = dbProvider.GetConnection();
        }

        public async Task Add(BookDto book)
        {
            await _books.InsertOneAsync(book);
        }

        public async Task<BookDto> Get(Guid id)
        {
            var result = await _books.FindAsync(book => book.Id == id);
            return await result.FirstOrDefaultAsync();
        }

        public async Task Update(BookDto book)
        {
            await _books.ReplaceOneAsync(x => x.Id == book.Id, book);
        }
    }
}