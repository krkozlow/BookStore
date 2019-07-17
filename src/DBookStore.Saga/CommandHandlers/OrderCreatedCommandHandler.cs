using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Saga.CommandHandlers
{
    public class OrderCreatedCommandHandler : ICommandHandler<OrderCreated>
    {
        private readonly IDistributedCache _cache;
        private readonly IBusClient _bus;

        public OrderCreatedCommandHandler(IDistributedCache cache, IBusClient bus)
        {
            _cache = cache;
            _bus = bus;
        }

        public async Task Handle(OrderCreated command)
        {
            await UpdateTransaction(command);

            CreatePayment payment = new CreatePayment
            {
                OrderId = command.OrderId
            };

            await _bus.PublishAsync(payment);
        }

        private async Task UpdateTransaction(OrderCreated command)
        {
            var existing = await _cache.GetStringAsync(command.TransactionId.ToString());
            var transaction = JsonConvert.DeserializeObject<OrderSagaTransaction>(existing);
            transaction.OrderId = command.OrderId;

            var value = JsonConvert.SerializeObject(transaction);
            await _cache.SetStringAsync(transaction.Id.ToString(), value);
        }
    }
}
