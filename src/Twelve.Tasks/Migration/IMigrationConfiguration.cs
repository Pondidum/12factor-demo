namespace Twelve.Tasks.Migration
{
	public interface IMigrationConfiguration
	{
		string PostgresConnection { get; }
	}
}
