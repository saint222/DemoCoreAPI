using System;
using System.Net;
using System.Security.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace DemoCoreAPIWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()     // Serilog.ASPNetCore
                .ReadFrom.Configuration(configuration) // Serilog.Settings.Configuration
                .CreateLogger();

            try
            {
                Log.Information("The application started");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The application failed while starting");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
//#if DEBUG
//                    webBuilder.ConfigureKestrel(options =>
//                    {
//                        options.Listen(IPAddress.Any, 84, listenOptions =>
//                        {
//                            listenOptions.UseHttps("certificate.pfx", "pwd");
//                        });
//                    });
//#endif
                    webBuilder.UseStartup<Startup>()
                        .UseDefaultServiceProvider(options =>
                        {
                            options.ValidateScopes = true; //Setting to true will validate scopes in all environments. This has performance implications.
                        });
                });
        }
    }
}