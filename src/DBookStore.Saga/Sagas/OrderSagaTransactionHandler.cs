using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using DBookStore.Common.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Saga.Sagas
{
    public class OrderSagaTransactionHandler : ICommandHandler<OrderSagaTransaction>
    {
        private readonly IDistributedCache _cache;
        private readonly IBusClient _bus;

        public OrderSagaTransactionHandler(IDistributedCache cache, IBusClient bus)
        {
            _cache = cache;
            _bus = bus;
        }

        public async Task Handle(OrderSagaTransaction command)
        {
            var transaction = new OrderSagaTransaction
            {
                Id = Guid.NewGuid(),
                State = TransactionState.Pending
            };

            var existing = await _cache.GetStringAsync(transaction.Id.ToString());
            if (existing == null)
            {
                var key = transaction.Id.ToString();
                var value = JsonConvert.SerializeObject(transaction).ToString();
                await _cache.SetStringAsync(key, value);
            }

            CreateOrder order = new CreateOrder
            {
                BookId = command.BookId,
                TransactionId = command.Id
            };

            await _bus.PublishAsync(order);
        }
    }
}
