using DBookStore.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBookStore.Common.Contracts
{
    public class CreateOrder : ICommand
    {
        public Guid TransactionId { get; set; }
        public Guid BookId { get; set; }
    }
}
