using ADAS.Application.BusinessLogic.Users.Commands.LoginUser;
using ADAS.Application.BusinessLogic.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ADAS.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
	private readonly ILogger<UserController> _logger;
	private readonly ISender _sender;

	public UserController(ILogger<UserController> logger, ISender sender)
	{
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_sender = sender ?? throw new ArgumentNullException(nameof(sender));
	}

	[HttpGet]
	public IActionResult Get()
	{
		_logger.LogInformation("Getting User");
		return Ok();
	}

	[HttpPost]
	public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
	{
		_logger.LogInformation("Registering User");
		var id = await _sender.Send(command);
		return Ok(id);
	}
	
	[HttpPost]
	public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
	{
		_logger.LogInformation("Registering User");
		var id = await _sender.Send(command);
		return Ok(id);
	}
	
}