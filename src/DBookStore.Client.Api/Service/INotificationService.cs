using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Client.Api.Service
{
    public interface INotificationService
    {
        Task NotifyClient(string connectionId, string message);

        Task NotifyAllClients(string message);
    }
}
