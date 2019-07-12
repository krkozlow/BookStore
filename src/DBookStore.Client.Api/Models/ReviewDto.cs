using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Client.Api.Models
{
    public class ReviewDto
    {
        public decimal Rating { get; set; }
        public string Description { get; set; }
    }
}
