using System;
using System.Collections.Generic;
using MediatR;

namespace Twelve.Api.Events
{
	public class CreateEventRequest : IRequest<CreateEventResponse>
	{
		public string Name { get; set; }
		public IEnumerable<string> Tags { get; set; }
		public DateTime Timestamp { get; set; }
	}
}
