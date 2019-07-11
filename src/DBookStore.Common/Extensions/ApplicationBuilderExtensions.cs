using DBookStore.Common.Commands;
using Microsoft.AspNetCore.Builder;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBookStore.Common.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddHandler<T>(this IApplicationBuilder app)
            where T : ICommand
        {
            if (!(app.ApplicationServices.GetService(typeof(IBusClient)) is IBusClient busClient))
                throw new NullReferenceException();

            if (!(app.ApplicationServices.GetService(typeof(ICommandHandler<T>)) is ICommandHandler<T> handler))
                throw new NullReferenceException();

            busClient
            .SubscribeAsync<T>(async (msg, context) =>
                {
                    await handler.Handle(msg);
                });
            return app;
        }
    }
}
