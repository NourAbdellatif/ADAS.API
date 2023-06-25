using Microsoft.AspNetCore.Mvc;

namespace ADAS.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	private readonly ILogger<UserController> _logger;

	public UserController(ILogger<UserController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public IActionResult Get()
	{
		_logger.LogInformation("Getting User");
		return Ok();
	}
	
}