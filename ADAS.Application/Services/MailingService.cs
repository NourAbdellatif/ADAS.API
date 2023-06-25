using ADAS.Application.Interfaces;
using ADAS.Application.Models.Emails;
using ADAS.Clients.Interfaces;
using ADAS.Clients.MailingClient;

namespace ADAS.Application.Services;

public class MailingService : IMailingService
{
	private readonly ISendGridClient _sendGridClient;
	private readonly IViewRender _viewRender;

	public MailingService(ISendGridClient sendGridClient, IViewRender viewRender)
	{
		_sendGridClient = sendGridClient ?? throw new ArgumentNullException(nameof(sendGridClient));
		_viewRender = viewRender ?? throw new ArgumentNullException(nameof(viewRender));
	}

	public async Task SendEmailAsync(UserRegistrationViewModel userModel)
	{
		var emailMessage = GenerateRegistirationEmail(userModel);
		await _sendGridClient.SendAsync(emailMessage);
	}
	private EmailMessage GenerateRegistirationEmail(UserRegistrationViewModel userModel)
	{
		var htmlBody = _viewRender.Render("Emails/Email", userModel);
		return new EmailMessage
		{
			Subject = "ADAS - Registration",
			HtmlBody = htmlBody,
			ReceiverEmail = userModel.Email
		};
	}
}