﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Consul;
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
				.UseUrls("http://localhost:5000")
				.ConfigureServices(services => services.AddSingleton(BuildConfiguration()))
				.Build();

		private static Configuration BuildConfiguration() => new ConfigurationBuilder()
			.AddEnvironmentVariables(ev => ev.Prefix = "twelve:")
			.AddConsul(prefix: "appsettings/twelve/")
			.Build()
			.Get<Configuration>() ?? new Configuration();
	}
}
