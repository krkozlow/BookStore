using DBookStore.Common.Commands;
using Microsoft.Extensions.Caching.Distributed;
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
            
        }
    }
}
