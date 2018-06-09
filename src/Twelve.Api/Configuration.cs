using System;

namespace Twelve.Api
{
	public class Configuration
	{
		public string PostgresConnection { get; set; }
		public string DatabaseName { get; set; }

		public Uri RabbitHost { get; set; }
		public string RabbitUsername { get; set; }
		public string RabbitPassword { get; set; }
	}
}