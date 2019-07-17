using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using DBookStore.Order.Service.Domain;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Order.Service.CommandHandlers
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrder>
    {
        private readonly IBusClient _bus;
        private readonly IOrderRepository _repository;

        public CreateOrderCommandHandler(IBusClient bus, IOrderRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public async Task Handle(CreateOrder command)
        {
            Domain.Order order = new Domain.Order
            {
                Id = Guid.NewGuid(),
                BookId = command.BookId
            };
            try
            {
                await _repository.Add(order);

                OrderCreated orderCreated = new OrderCreated
                {
                    OrderId = order.Id,
                    TransactionId = command.TransactionId
                };

                await _bus.PublishAsync(orderCreated);
            }
            catch (Exception exception)
            {
                CreateOrderFailed failed = new CreateOrderFailed
                {
                    OrderId = order.Id
                };

                await _bus.PublishAsync(failed);
            }
        }
    }
}