using Oakton;

namespace Twelve.Tasks.Migration
{
	public class MigrateInput
	{
		[Description("Optionally specify which version to migrate to")]
		public int Version { get; set; }
	}
}
