using ADAS.Application.BusinessLogic.Bugs.Commands.CreateBugTicket;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ADAS.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BugController : ControllerBase
{
	private readonly ISender _sender;

	public BugController(ISender sender)
	{
		_sender = sender ?? throw new ArgumentNullException(nameof(sender));
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateBugTicketCommand command)
	{
		await _sender.Send(command);
		return Ok();
	}
}