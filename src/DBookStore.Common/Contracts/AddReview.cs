using DBookStore.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBookStore.Common.Contracts
{
    public class AddReview : ICommand
    {
        public Guid BookId { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
    }
}
