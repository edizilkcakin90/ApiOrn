using BLL;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ApiOrnek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            Logger.Log("Logging has been started successfully!");
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("https://localhost:5000/")
                .Build();
    }
}
