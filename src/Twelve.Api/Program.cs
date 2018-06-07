using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Consul;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Json;

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
				.UseUrls("http://localhost:5000")
				.ConfigureServices(services => services.AddSingleton(BuildConfiguration()))
				.ConfigureLogging(UseSerilogOnly)
				.Build();

		private static Configuration BuildConfiguration() => new ConfigurationBuilder()
			.AddEnvironmentVariables(ev => ev.Prefix = "twelve:")
			.AddConsul(prefix: "appsettings/twelve/")
			.Build()
			.Get<Configuration>() ?? new Configuration();

		private static void UseSerilogOnly(ILoggingBuilder logging)
		{
			logging.ClearProviders();
			logging.AddSerilog(new LoggerConfiguration()
				.WriteTo.Console(new JsonFormatter())
				.CreateLogger()
			);
		}
	}
}
