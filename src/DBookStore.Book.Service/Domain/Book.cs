using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Book.Service.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Release { get; set; }
    }
}
