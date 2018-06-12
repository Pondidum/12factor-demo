using System;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Oakton;

namespace Twelve.Tasks.Migration
{
	[Description("Migrates the Postgres database schema")]
	public class MigrateCommand : OaktonAsyncCommand<MigrateInput>
	{
		public MigrateCommand()
		{
			Usage("Migrate to latest version");
			Usage("Migrate to a specific version").Arguments(x => x.Version);
		}

		public override async Task<bool> Execute(MigrateInput input)
		{
			await Console.Out.WriteLineAsync("Nothing to migrate");
//			var serviceProvider = CreateServiceProvider(_config);
//			using (var scope = serviceProvider.CreateScope())
//			{
//				var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
//				runner.MigrateUp();
//			}

			return true;
		}

		private static IServiceProvider CreateServiceProvider(IMigrationConfiguration config) => new ServiceCollection()
			.AddFluentMigratorCore()
			.ConfigureRunner(runner => runner
				.AddPostgres()
				.WithGlobalConnectionString(config.PostgresConnection)
				.ScanIn(typeof(MigrateCommand).Assembly).For.Migrations())
			.AddLogging(logger => logger.AddFluentMigratorConsole())
			.BuildServiceProvider(false);
	}
}
