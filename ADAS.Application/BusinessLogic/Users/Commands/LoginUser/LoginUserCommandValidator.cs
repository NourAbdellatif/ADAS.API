using ADAS.Application.Common.Validators;
using ADAS.Application.Interfaces;
using FluentValidation;

namespace ADAS.Application.BusinessLogic.Users.Commands.LoginUser;

public class LoginUserCommandValidator : BaseUserCommandValidator<LoginUserCommand>
{
	private readonly IAdasDbContext _context;
	public LoginUserCommandValidator(IAdasDbContext context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
		RuleFor(x => x.Email)
			.NotEmpty()
			.EmailAddress();

		RuleFor(x => new { x.Email, x.Password })
			.Must(body =>
			{
				return _context.Users.Any(u => u.Email == body.Email && u.Password == body.Password);
			})
			.WithMessage("Invalid email or password provided.");
	}
}