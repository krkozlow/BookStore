using DBookStore.Common.DbProvider;
using DBookStore.Order.Service.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Order.Service.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Domain.Order> _orders;

        public OrderRepository(IMongoDbProvider<Domain.Order> dbProvider)
        {
            _orders = dbProvider.GetConnection();
        }

        public async Task Add(Domain.Order order)
        {
            await _orders.InsertOneAsync(order);
        }

        public async Task Delete(Guid id)
        {
            await _orders.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<Domain.Order> Get(Guid id)
        {
            var result = await _orders.FindAsync(x => x.Id == id);
            return await result.FirstOrDefaultAsync();
        }
    }
}
