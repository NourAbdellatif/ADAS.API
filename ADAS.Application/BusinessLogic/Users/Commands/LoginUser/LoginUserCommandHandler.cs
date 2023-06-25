using ADAS.Application.Interfaces;
using MediatR;

namespace ADAS.Application.BusinessLogic.Users.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
{
	private readonly IAdasDbContext _context;

	public LoginUserCommandHandler(IAdasDbContext context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
	}

	public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
	{
		return _context.Users.Any(u => u.Email == request.Email && u.Password == request.Password);
	}
}