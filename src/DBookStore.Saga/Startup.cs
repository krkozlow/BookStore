﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBookStore.Common.Commands;
using DBookStore.Common.Contracts;
using DBookStore.Common.Extensions;
using DBookStore.Saga.Sagas;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DBookStore.Saga
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
            services.AddTransient<ICommandHandler<OrderSagaTransaction>, OrderSagaTransactionHandler>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = "127.0.0.1:6379";
            });
            services.AddRabbitMq();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.AddHandler<OrderSagaTransaction>();
            //app.AddHandler<OrderCreated>();
            //app.AddHandler<CreateOrderFailed>();
            //app.AddHandler<PaymentCreated>();
            //app.AddHandler<CreatePayment>();
            //app.AddHandler<DeliveryCreated>();
            //app.AddHandler<CreateDeliveryFailed>();
        }
    }
}