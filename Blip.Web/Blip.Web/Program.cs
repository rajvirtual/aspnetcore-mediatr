using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace Blip.Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                           .MinimumLevel.Debug()
                           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                           .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                           .Enrich.FromLogContext()
                           .WriteTo.Console()
                           .WriteTo.Seq("http://localhost:5341")
                           .CreateLogger();
            try
            {
                Log.Information("Starting host");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
