using System;
using System.Threading.Tasks;
using Oakton;

namespace Twelve.Tasks.Inspect
{
	[Description("Inspects various items stored by the service")]
	public class InspectCommand : OaktonAsyncCommand<InspectInput>
	{
		public InspectCommand()
		{
			Usage("Count things").Arguments(x => x.Thing).ValidFlags(x => x.StatsFlag);
			Usage("Inspect a specific thing").Arguments(x => x.Thing).ValidFlags(x => x.IDFlag);
		}

		public override async Task<bool> Execute(InspectInput input)
		{
			if (input.StatsFlag)
				await Console.Out.WriteLineAsync($"No stats for {input.Thing.ToString()} :(");

			if (input.IDFlag.HasValue)
			{
				await Console.Out.WriteLineAsync($"Found one {input.Thing.ToString()} with id {input.IDFlag}");
				await Console.Out.WriteLineAsync($"    Last activity: {DateTime.Now.AddDays(-5)}");
			}


			return true;
		}
	}
}
