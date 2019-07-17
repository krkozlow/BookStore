using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Order.Service.Domain
{
    public interface IOrderRepository
    {
        Task Add(Order order);
        Task Delete(Guid id);
        Task<Order> Get(Guid id);
    }
}
