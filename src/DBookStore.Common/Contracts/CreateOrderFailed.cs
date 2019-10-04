using DBookStore.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBookStore.Common.Contracts
{
    public class CreateOrderFailed : ICommand
    {
        public Guid OrderId { get; set; }
        public string Message { get; set; }
    }
}
