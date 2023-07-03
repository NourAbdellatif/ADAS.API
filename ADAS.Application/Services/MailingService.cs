using ADAS.Application.Interfaces;
using ADAS.Application.Models.Emails;
using ADAS.Clients.Interfaces;
using ADAS.Clients.MailingClient;
using Microsoft.Extensions.Options;

namespace ADAS.Application.Services;

public class MailingService : IMailingService
{
	private readonly ISendGridClient _sendGridClient;
	private readonly IViewRender _viewRender;
	private readonly EmailConfiguration _emailConfig;

	public MailingService(ISendGridClient sendGridClient, IViewRender viewRender, IOptions<EmailConfiguration> config)
	{
		_sendGridClient = sendGridClient ?? throw new ArgumentNullException(nameof(sendGridClient));
		_viewRender = viewRender ?? throw new ArgumentNullException(nameof(viewRender));
		_emailConfig = config?.Value ?? throw new ArgumentNullException(nameof(config));
	}

	public async Task SendRegistrationEmailAsync(UserRegistrationViewModel userModel)
	{
		var emailMessage = GenerateRegistrationEmail(userModel);
		await _sendGridClient.SendAsync(emailMessage);
	}

	public async Task SendBugReportEmailAsync(BugReportViewModel bugReportViewModel)
	{
		var emailMessage = GenerateBugReportEmail(bugReportViewModel);
		await _sendGridClient.SendAsync(emailMessage);
	}

	public async Task SendActivateEmailAsync(ActivateEmailViewModel userModel)
	{
		var emailMessage = GenerateActivateEmail(userModel);
		await _sendGridClient.SendAsync(emailMessage);
	}
	
	private EmailMessage GenerateActivateEmail(ActivateEmailViewModel userModel)
	{
		var htmlBody = _viewRender.Render("Emails/ActivateEmail", userModel);
		return new EmailMessage
		{
			Subject = "ADAS - Activate Email",
			HtmlBody = htmlBody,
			ReceiverEmail = userModel.Email
		};
	}

	private EmailMessage GenerateBugReportEmail(BugReportViewModel bugReportViewModel)
	{
		var htmlBody = _viewRender.Render("Emails/BugReport", bugReportViewModel);
		return new EmailMessage
		{
			Subject = "ADAS - Bug Report",
			HtmlBody = htmlBody,
			ReceiverEmail = _emailConfig.FromEmail,
			FromEmail = _emailConfig.AdminEmail,
			FromName = _emailConfig.AdminName
		};
	}

	private EmailMessage GenerateRegistrationEmail(UserRegistrationViewModel userModel)
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