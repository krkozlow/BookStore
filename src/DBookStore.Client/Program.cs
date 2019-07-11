using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DBookStore.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5051/notification")
                .Build();
            connection.On<string>("HandleNotification", (message) =>
            {
                Console.WriteLine(message);
            });
            await connection.StartAsync();

            Console.ReadKey();
        }
    }
}
