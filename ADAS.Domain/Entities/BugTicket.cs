namespace ADAS.Domain.Entities;

public class BugTicket : EntityBase
{
	public string Title { get; set; }
	public string Description { get; set; }
	public string UserId { get; set; }
	public User User { get; set; }
	public bool IsResolved { get; set; }
}