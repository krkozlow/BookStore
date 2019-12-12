using DBookStore.Book.Service.Domain;
using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Book.Service.CommandHandlers
{
    public class CreateBookCommandHandler : ICommandHandler<CreateBook>
    {
        private readonly IBusClient _bus;
        private readonly IBookRepository _repository;

        public CreateBookCommandHandler(IBusClient bus, IBookRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public async Task Handle(CreateBook command)
        {
            Console.WriteLine($"{DateTime.Now.Ticks} CreateBookCommandHandler");
            var bookId = Guid.NewGuid();
            await _repository.Add(new Domain.Book
            {
                Id = bookId,
                Name = command.Name,
                Release = command.Release,
                Genre = command.Genre
            });

            await _bus.PublishAsync(new BookCreated
            {
                Id = bookId,
                ResourceUrl = $"http://localhost:5002/api/book/"
            });
        }
    }
}
