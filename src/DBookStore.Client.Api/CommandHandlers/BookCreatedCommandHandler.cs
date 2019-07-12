using DBookStore.Client.Api.Hubs;
using DBookStore.Client.Api.Repository;
using DBookStore.Client.Api.Service;
using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using Microsoft.AspNetCore.SignalR;
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
        private readonly INotificationService _notificationService;

        public BookCreatedCommandHandler(IBookRepository repository, INotificationService notificationService)
        {
            _repository = repository;
            _notificationService = notificationService;
            _client = new HttpClient();
        }

        public async Task Handle(BookCreated command)
        {
            var message = $"{DateTime.Now.Ticks} BookCreatedCommandHandler";
            Console.WriteLine(message);
            var response = await _client.GetStringAsync(command.ResourceUrl + command.Id);
            var result = JsonConvert.DeserializeObject<Book.Service.Domain.Book>(response);

            await _repository.Add(new BookDto
            {
                Id = result.Id,
                Name = result.Name,
                Release = result.Release
            });

            await _notificationService.NotifyAllClients(message);
        }
    }
}
