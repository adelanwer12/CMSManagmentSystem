using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataAccessService;
using DataAccessService.InterFaces;
using DataService;
using DataService.DataBaseContexts;
using loggingService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    var seedData = service.GetRequiredService<ISeedData>();
                    await DbContextInitializer.DataBaseInitialize(seedData);
                }
                catch (Exception ex)
                {
                    Log.Error("An error occurred while seeding database {Error} {StackTrace} {InnerException} {Source}", ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                      .Enrich.FromLogContext().Enrich.WithProperty("Application", "Api").Enrich
                             .WithProperty("MachineName", Environment.MachineName).Enrich
                             .WithProperty("CurrentManagedThreadId", Environment.CurrentManagedThreadId).Enrich
                             .WithProperty("OSVersion", Environment.OSVersion).Enrich
                             .WithProperty("Version", Environment.Version).Enrich
                             .WithProperty("UserName", Environment.UserName).Enrich
                             .WithProperty("ProcessId", Process.GetCurrentProcess().Id).Enrich
                             .WithProperty("ProcessName", Process.GetCurrentProcess().ProcessName)
                             .WriteTo.Console(theme: CustomConsoleTheme.VisualStudioMacLight)
                             .WriteTo.File(formatter: new CustomTextFormatter(), path: Path.Combine(hostingContext.HostingEnvironment.ContentRootPath + $"{Path.DirectorySeparatorChar}Logs{Path.DirectorySeparatorChar}", $"cms_api_{DateTime.Now:yyyyMMdd}.txt"))
                             .ReadFrom.Configuration(hostingContext.Configuration));
                    webBuilder.UseStartup<Startup>();
                });
    }
}