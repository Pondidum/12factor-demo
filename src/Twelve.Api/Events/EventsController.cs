using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Twelve.Api.Events
{
	public class EventsController : Controller
	{
		private readonly IMediator _mediator;

		public EventsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Store([FromBody] CreateEventRequest request)
		{
			var resposne = await _mediator.Send(request);

			return Created("/events/" + resposne.ID, null);
		}
	}
}
