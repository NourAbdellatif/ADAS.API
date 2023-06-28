using MediatR;

namespace ADAS.Application.BusinessLogic.Users.Commands.ValidateEmail;

public class ValidateUserEmailCommand : IRequest<bool>
{
	public string Email { get; set; }
}