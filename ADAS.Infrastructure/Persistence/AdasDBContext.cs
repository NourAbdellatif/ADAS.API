using ADAS.Application.Interfaces;
using ADAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ADAS.Infrastructure.Persistence;

public class AdasDBContext : DbContext, IAdasDbContext
{
	public AdasDBContext(DbContextOptions<AdasDBContext> options) : base(options)
	{
	}
	
	public DbSet<User> Users => Set<User>();

}