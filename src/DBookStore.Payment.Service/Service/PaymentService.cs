using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBookStore.Payment.Service.Domain;

namespace DBookStore.Payment.Service.Service
{
    public class PaymentService : IPaymentService
    {
        public Task Pay(Domain.Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
