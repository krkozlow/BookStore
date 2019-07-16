using DBookStore.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Saga.Sagas
{
    public class OrderSagaTransaction : ICommand
    {
        public Guid Id { get; set; }
        public SagaState State { get; set; }
    }
}
