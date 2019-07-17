using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBookStore.Order.Service.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DBookStore.Order.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Order>> Get(Guid id)
        {
            var order = await _repository.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}