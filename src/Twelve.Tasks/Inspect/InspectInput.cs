using System;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Oakton;

namespace Twelve.Tasks.Inspect
{
	public class InspectInput
	{
		public Things Thing { get; set; }

		public bool StatsFlag { get; set; }
	}

	public enum Things
	{
		Users,
		Images
	}

	[Description("Inspects various items stored by the service")]
	public class InspectCommand : OaktonAsyncCommand<InspectInput>
	{
		public InspectCommand()
		{
			Usage("Count things").Arguments(x => x.Thing).ValidFlags(x => x.StatsFlag);
		}

		public override async Task<bool> Execute(InspectInput input)
		{
			await Console.Out.WriteLineAsync(input.Thing.ToString());

			if (input.StatsFlag)
				await Console.Out.WriteLineAsync("No stats :(");

			return true;
		}
	}
}
