using ADAS.Application.Interfaces;
using MediatR;

namespace ADAS.Application.BusinessLogic.Users.Commands.ValidateEmail;

public class ValidateUserEmailCommandHandler : IRequestHandler<ValidateUserEmailCommand, bool>
{
	private readonly IAdasDbContext _context;

	public ValidateUserEmailCommandHandler(IAdasDbContext context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
	}

	public async Task<bool> Handle(ValidateUserEmailCommand request, CancellationToken cancellationToken)
	{
		return _context.Users.Any(u => u.Email == request.Email);
	}
}