using System;
using MediatR;
using Npgsql;

namespace Twelve.Api.Events
{
	public class CreateEventHandler : RequestHandler<CreateEventRequest, CreateEventResponse>
	{
		private readonly Configuration _configuration;

		public CreateEventHandler(Configuration configuration)
		{
			_configuration = configuration;
		}

		protected override CreateEventResponse Handle(CreateEventRequest request)
		{
			using (var connection = new NpgsqlConnection(_configuration.PostgresConnection))
			{
				connection.Open();

				//store it somehow...
				return new CreateEventResponse { ID = Guid.NewGuid() };
			}
		}
	}
}
