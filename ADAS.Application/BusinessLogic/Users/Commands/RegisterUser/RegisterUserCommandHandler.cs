using ADAS.Application.Common.DTOs;
using ADAS.Application.Interfaces;
using ADAS.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ADAS.Application.BusinessLogic.Users.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseEntityDTO>
{
	private readonly IAdasDbContext _context;
	private readonly IMapper _mapper;

	public RegisterUserCommandHandler(IAdasDbContext context, IMapper mapper)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
		_mapper = mapper ??  throw new ArgumentNullException(nameof(mapper));
	}

	public async Task<BaseEntityDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
	{
		var user = _mapper.Map<User>(request);
		await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync(cancellationToken);
		return new BaseEntityDTO()
		{
			Id = user.Id,
		};
	}
}