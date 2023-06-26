namespace ADAS.Application.Models.Emails;

public class BugReportViewModel
{
	public string Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public string UserId { get; set; }
	public string UserEmail { get; set; }
}