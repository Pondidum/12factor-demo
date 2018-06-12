using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Twelve.Api.Events
{
	public class EventsController : Controller
	{
		[HttpPost]
		public IActionResult Post([FromBody] CreateEventRequest request)
		{
			return Json(request);
		}
	}

	public class CreateEventRequest
	{
		public string Name { get; set; }
		public IEnumerable<string> Tags { get; set; }
		public DateTime Timestamp { get; set; }
	}
}
