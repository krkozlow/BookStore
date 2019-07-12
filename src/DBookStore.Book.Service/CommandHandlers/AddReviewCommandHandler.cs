using DBookStore.Book.Service.Service;
using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Book.Service.CommandHandlers
{
    public class AddReviewCommandHandler : ICommandHandler<AddReview>
    {
        private readonly IBookService _service;
        private readonly IBusClient _bus;

        public AddReviewCommandHandler(IBookService service, IBusClient bus)
        {
            _service = service;
            _bus = bus;
        }

        public async Task Handle(AddReview command)
        {
            Domain.Review review = new Domain.Review
            {
                Description = command.Description,
                Rating = command.Rating
            };
            await _service.AddReview(command.BookId, review);

            ReviewAdded reviewAdded = new ReviewAdded
            {
                Message = $"{DateTime.UtcNow.Ticks} Review added to {command.BookId}"
            };
            await _bus.PublishAsync(reviewAdded);
        }
    }
}
