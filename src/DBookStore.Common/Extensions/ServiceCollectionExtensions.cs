using DBookStore.Common.DbProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.vNext;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBookStore.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRabbitMq(this IServiceCollection services)
        {
            var options = new RawRabbitConfiguration
            {
                Username = "guest",
                Password = "guest",
                Port = 5672,
                VirtualHost = "/",
                Hostnames = { "localhost" }
            };
            var client = BusClientFactory.CreateDefault(options);
            services.AddSingleton<IBusClient>(_ => client);
        }

        public static void AddMongoDbProvider<T>(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMongoDbProvider<T>>(_ => new MongoDbProvider<T>(configuration));
        }
    }
}
