using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBookStore.Client.Api.CommandHandlers;
using DBookStore.Client.Api.Repository;
using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using DBookStore.Common.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DBookStore.Client.Api.Hubs;
using DBookStore.Client.Api.Service;
using DBookStore.Book.Service.CommandHandlers;

namespace DBookStore.Client.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ICommandHandler<BookCreated>, BookCreatedCommandHandler>();
            services.AddTransient<ICommandHandler<ReviewAdded>, ReviewAddedCommandHandler>();
            services.AddMongoDbProvider<BookDto>(Configuration);
            services.AddRabbitMq();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
            app.AddHandler<BookCreated>();
            app.AddHandler<ReviewAdded>();
            app.UseSignalR(hubs => 
            {
                hubs.MapHub<NotificationHub>("/notification");
            });
        }
    }
}
