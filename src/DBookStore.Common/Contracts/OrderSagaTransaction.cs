using DBookStore.Common.Commands;
using DBookStore.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBookStore.Common.Contracts
{
    public class OrderSagaTransaction : ICommand
    {
        public Guid Id { get; set; }
        public TransactionState State { get; set; }
        public Guid BookId { get; set; }
        public Guid OrderId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid DeliveryId { get; set; }
    }
}