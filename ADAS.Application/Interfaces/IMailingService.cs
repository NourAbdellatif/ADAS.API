using ADAS.Application.Models.Emails;

namespace ADAS.Application.Interfaces;

public interface IMailingService
{
	public Task SendEmailAsync(UserRegistrationViewModel userModel);
}