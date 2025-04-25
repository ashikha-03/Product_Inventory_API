using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ProductInventoryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Build and run the web host using Startup class
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();  // Use the Startup class for configuration
                });
    }
}
