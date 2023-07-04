using ADAS.Application.Constants;
using ADAS.Application.Interfaces;
using ADAS.Application.Models.Emails;
using ADAS.Application.Utilities;
using MediatR;

namespace ADAS.Application.BusinessLogic.Users.Commands.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Unit>
{
	private readonly IMailingService _mailingService;

	public ForgotPasswordCommandHandler(IMailingService mailingService)
	{
		_mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
	}

	public async Task<Unit> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
	{
		var forgotPasswordModel = new ForgotPasswordViewModel()
		{
			Email = request.Email,
			Password = Functions.RandomString()
		};
		await _mailingService.SendEmailAsync(forgotPasswordModel, EmailSubjects.ForgotPassword);
		return Unit.Value;
	}
}