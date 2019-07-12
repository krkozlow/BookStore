using DBookStore.Client.Api.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Client.Api.Service
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyClient(string connectionId, string message)
        {
            await _hubContext.Clients.Client(connectionId).SendAsync("HandleNotification", message);
        }

        public async Task NotifyAllClients(string message)
        {
            await _hubContext.Clients.All.SendAsync("HandleNotification", message);
        }
    }
}
