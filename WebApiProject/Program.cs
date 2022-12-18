using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Data.Access;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostbuilder = CreateHostBuilder(args).Build();

            using(var scope = hostbuilder.Services.CreateScope()) {
                var serviceProvider = scope.ServiceProvider;
                try {
                    var cntx = serviceProvider.GetRequiredService<ProjectAppDBcontext>();
                    DBInitialize.Initialize(cntx);
                }
                catch (Exception e) {

                }
            }

            hostbuilder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
