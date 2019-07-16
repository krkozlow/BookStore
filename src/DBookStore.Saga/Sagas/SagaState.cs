using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Saga.Sagas
{
    public enum SagaState
    {
        Pending,
        Finished,
        Failed
    }
}
