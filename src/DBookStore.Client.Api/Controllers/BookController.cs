using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBookStore.Client.Api.Models;
using DBookStore.Common.Contracts;
using DBookStore.Common.Models;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace DBookStore.Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBusClient _bus;

        public BookController(IBusClient bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookDto model)
        {
            CreateBook book = new CreateBook
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Release = model.Release.ToUniversalTime(),
                Genre = model.Genre
            };
            await _bus.PublishAsync(book);

            return Accepted(book);
        }

        [HttpPost("{bookId}")]
        public async Task<IActionResult> Post(Guid bookId, [FromBody] ReviewDto model)
        {
            AddReview review = new AddReview
            {
                BookId = bookId,
                Rating = model.Rating,
                Description = model.Description
            };
            await _bus.PublishAsync(review);

            return Accepted(review);
        }

        [HttpGet("[action]/{bookId}")]
        public async Task<IActionResult> Order(Guid bookId)
        {
            OrderSagaTransaction orderSagaTransaction = new OrderSagaTransaction
            {
                Id = Guid.NewGuid(),
                State = TransactionState.Pending,
                BookId = bookId
            };
            await _bus.PublishAsync(orderSagaTransaction);

            return Accepted(orderSagaTransaction);
        }
    }
}
