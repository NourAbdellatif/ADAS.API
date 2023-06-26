using ADAS.Application.Common.DTOs;
using ADAS.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ADAS.Application.BusinessLogic.Users.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseEntityDTO>
{
	private readonly IAdasDbContext _context;

	public LoginUserCommandHandler(IAdasDbContext context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
	}

	public async Task<BaseEntityDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
	{
		var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password);
		return new BaseEntityDTO()
		{
			Id = user.Id
		};
	}
}