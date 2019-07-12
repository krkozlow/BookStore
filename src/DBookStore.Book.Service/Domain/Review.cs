using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Book.Service.Domain
{
    public class Review
    {
        public Guid UserId { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
    }
}
