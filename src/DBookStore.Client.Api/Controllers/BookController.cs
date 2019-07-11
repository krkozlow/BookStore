using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBookStore.Common.Contracts;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                CreateBook book = new CreateBook
                {
                    Id = Guid.NewGuid(),
                    Name = "Test name",
                    Release = DateTime.UtcNow
                };
                await _bus.PublishAsync(book);

                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookDto model)
        {
            CreateBook book = new CreateBook
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Release = model.Release.ToUniversalTime()
            };
            await _bus.PublishAsync(book);

            return Accepted();
        }
    }
}
