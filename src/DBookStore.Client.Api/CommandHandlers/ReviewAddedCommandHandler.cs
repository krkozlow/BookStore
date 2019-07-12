using DBookStore.Book.Service.Domain;
using DBookStore.Client.Api.Models;
using DBookStore.Client.Api.Repository;
using DBookStore.Client.Api.Service;
using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IBookRepository = DBookStore.Client.Api.Repository.IBookRepository;

namespace DBookStore.Client.Api.CommandHandlers
{
    public class ReviewAddedCommandHandler : ICommandHandler<ReviewAdded>
    {
        private readonly IBookRepository _repository;
        private readonly HttpClient _client;
        private readonly INotificationService _notificationService;

        public ReviewAddedCommandHandler(IBookRepository repository, INotificationService notificationService)
        {
            _repository = repository;
            _notificationService = notificationService;
            _client = new HttpClient();
        }

        public async Task Handle(ReviewAdded command)
        {
            var message = $"{DateTime.Now.Ticks} ReviewAddedCommandHandler";
            Console.WriteLine(message);
            var response = await _client.GetStringAsync(command.ResourceUrl + command.Id);
            var result = JsonConvert.DeserializeObject<Book.Service.Domain.Book>(response);

            await _repository.Update(new BookDto
            {
                Id = result.Id,
                Name = result.Name,
                Release = result.Release,
                Genre = result.Genre,
                Reviews = MapReviews(result.Reviews)
            });

            await _notificationService.NotifyAllClients(message);
        }

        private IEnumerable<ReviewDto> MapReviews(IEnumerable<Review> reviews)
        {
            foreach (var review in reviews)
            {
                yield return new ReviewDto
                {
                    Rating = review.Rating,
                    Description = review.Description
                };
            }
        }
    }
}
