using BLL;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ApiOrnek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            Logger.Log("Logging has been started successfully!");
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
