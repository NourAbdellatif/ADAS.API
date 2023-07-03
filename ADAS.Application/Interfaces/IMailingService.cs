using ADAS.Application.Models.Emails;

namespace ADAS.Application.Interfaces;

public interface IMailingService
{
	public Task SendRegistrationEmailAsync(UserRegistrationViewModel userModel);
	public Task SendBugReportEmailAsync(BugReportViewModel bugReportViewModel);
	public Task SendActivateEmailAsync(ActivateEmailViewModel userModel);
}