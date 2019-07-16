using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Client.Api.Models
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
    }
}
