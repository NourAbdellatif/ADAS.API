using ADAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ADAS.Application.Interfaces;

public interface IAdasDbContext
{
	DbSet<User> Users { get; }
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}