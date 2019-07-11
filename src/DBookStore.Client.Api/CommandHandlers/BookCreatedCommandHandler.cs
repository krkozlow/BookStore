using DBookStore.Client.Api.Hubs;
using DBookStore.Client.Api.Repository;
using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DBookStore.Client.Api.CommandHandlers
{
    public class BookCreatedCommandHandler : ICommandHandler<BookCreated>
    {
        private readonly IBookRepository _repository;
        private readonly HttpClient _client;

        public BookCreatedCommandHandler(IBookRepository repository)
        {
            _repository = repository;
            _client = new HttpClient();
        }

        public async Task Handle(BookCreated command)
        {
            Console.WriteLine($"{DateTime.Now.Ticks} BookCreatedCommandHandler");
            var response = await _client.GetStringAsync(command.ResourceUrl + command.Id);
            var result = JsonConvert.DeserializeObject<Book.Service.Domain.Book>(response);

            await _repository.Add(new BookDto
            {
                Id = result.Id,
                Name = result.Name,
                Release = result.Release
            });

            var hub = new NotificationHub();
            await hub.NotifyClient($"{DateTime.Now.Ticks} BookCreatedCommandHandler");
        }
    }
}
