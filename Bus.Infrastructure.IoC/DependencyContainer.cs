﻿using MediatR;
using Bus.Domain.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Bus.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            //MediatR Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp => {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = sp.GetService<IOptions<RabbitMQSettings>>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, optionsFactory);
            });

            return services;
        }
    }
}