﻿namespace ADAS.Domain.Entities;

public class User : EntityBase
{
	public string Email { get; set; }
	public string Password { get; set; }
	public bool IsActive { get; set; }
}