using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Payment.Service.Service
{
    public interface IPaymentService
    {
        Task Pay(Domain.Payment payment);
    }
}
