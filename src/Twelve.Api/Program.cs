using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Twelve.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureServices(services => services
                    .AddSingleton(new ConfigurationBuilder()
                        .AddEnvironmentVariables(ev => ev.Prefix = "twelve:")
                        .Build()
                        .Get<Configuration>()))
                .Build();
    }
}
