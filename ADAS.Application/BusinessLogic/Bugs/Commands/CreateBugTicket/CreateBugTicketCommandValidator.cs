using ADAS.Application.Constants;
using ADAS.Application.Interfaces;
using FluentValidation;

namespace ADAS.Application.BusinessLogic.Bugs.Commands.CreateBugTicket;

public class CreateBugTicketCommandValidator : AbstractValidator<CreateBugTicketCommand>
{
	private readonly IAdasDbContext _context;
	public CreateBugTicketCommandValidator(IAdasDbContext context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
		
		RuleFor(c => c.UserId)
			.Must(id => _context.Users.Any(u => u.Id == id))
			.WithMessage("User with this id does not exist");
		
		RuleFor(c => c.Title)
			.NotEmpty()
			.Must(title => title.Length < FieldLength.Small)
			.WithMessage("Title cannot be empty");

		RuleFor(c => c.Description)
			.NotEmpty()
			.Must(description => description.Length < FieldLength.Large);
	}
}