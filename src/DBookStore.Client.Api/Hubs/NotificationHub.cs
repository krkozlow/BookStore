using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBookStore.Client.Api.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task NotifyClient(string message)
        {
            await Clients.All.SendAsync("HandleNotification", message);
        }
    }
}
