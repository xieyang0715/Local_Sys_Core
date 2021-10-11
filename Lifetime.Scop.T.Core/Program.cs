using Lifetime.Scop.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lifetime.Scop.T.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var _logger = services.GetRequiredService<ILogger<Program>>();
                    var a = services.GetRequiredService<IOperationSingleton>();
                    var a1 = services.GetRequiredService<IOperationSingleton>();
                    var b = services.GetRequiredService<IOperationScoped>();
                    var b1 = services.GetRequiredService<IOperationScoped>();
                    var b2 = services.GetRequiredService<IOperationScoped>();
                    var c = services.GetRequiredService<IOperationTransient>();
                    var c1 = services.GetRequiredService<IOperationTransient>();
                    _logger.LogInformation("Transient: " + a.OperationId);
                    _logger.LogInformation("Transienta1: " + a1.OperationId);
                    _logger.LogInformation("Scoped: " + b.OperationId);
                    _logger.LogInformation("Scopedb1: " + b1.OperationId);
                    _logger.LogInformation("Scopedb2: " + b2.OperationId);
                    _logger.LogInformation("Singleton: " + c.OperationId);
                    _logger.LogInformation("Singleton1: " + c1.OperationId);
                }
                catch (Exception ex)
                {
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging=> {
                logging.AddConsole(); logging.AddDebug();
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    public interface IMyDependency
    {
        void WriteMessage(string message);
    }
}
