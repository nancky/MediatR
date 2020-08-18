using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace MediatR_Console
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddMediatR(typeof(Program));
            services.AddSingleton<IPingService, PingService>();
            services.AddSingleton<ConsoleApplication>();
            services.AddLogging(configure => configure.AddConsole())
                .AddTransient<PingEventHandler>();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }

}

