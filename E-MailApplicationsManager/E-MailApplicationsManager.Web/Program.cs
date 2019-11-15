using E_MailApplicationsManager.Service.Service;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace E_MailApplicationsManager.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //We read from the "appsettings.json" file
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Application Starting Up");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                //we use Fatal in case if app crashes 
                Log.Fatal(ex, "The app failed to start correctly.");
            }
            finally
            {
                //It's a "shutdown" method that ensures any buffered 
                //events are processed before the application exits.
                Log.CloseAndFlush();
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseStartup<Startup>();
    }
}
