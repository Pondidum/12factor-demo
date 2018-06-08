using System.Reflection;
using System.Threading.Tasks;
using Oakton;
using Oakton.Help;

namespace Twelve.Tasks
{
	class Program
	{
		static async Task<int> Main(string[] args)
		{
			return await CommandExecutor
				.For(_ =>
				{
					_.RegisterCommands(typeof(Program).Assembly);
					_.DefaultCommand = null;
				})
				.ExecuteAsync(args);
		}
	}
}
