﻿namespace ADAS.Clients.MailingClient;

public class EmailConfiguration
{
	public string APIKey { get; set; }
	public string FromEmail { get; set; }
	public string FromName { get; set; }
	public bool IsEmailEnabled { get; set; }
}