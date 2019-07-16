using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using DBookStore.Common.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Saga.Sagas
{
    public class OrderSagaTransactionHandler : ICommandHandler<OrderSagaTransaction>
    {
        private readonly IDistributedCache _cache;

        public OrderSagaTransactionHandler(IDistributedCache cache)
        {
            _cache = cache;
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
        }
    }
}
