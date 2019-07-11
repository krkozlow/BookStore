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
        public CreateBookCommandHandler(IBusClient bus)
        {
            _bus = bus;
        }

        public async Task Handle(CreateBook command)
        {
            Console.WriteLine($"{DateTime.Now.Ticks} CreateBookCommandHandler");
            BookCreated book = new BookCreated
            {
                Id = Guid.NewGuid(),
                ResourceUrl = $"https://localhost:5001/api/book/"
            };
            //save to books db
            await _bus.PublishAsync(book);
        }
    }
}
