﻿using ADAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ADAS.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(u => u.Id);
		
		builder.Property(u => u.Id)
			.ValueGeneratedOnAdd();

		builder.HasMany(u => u.BugTickets)
			.WithOne(b => b.User)
			.HasForeignKey(b => b.UserId);

		builder.Property(u => u.Email)
			.IsRequired();
	}
}