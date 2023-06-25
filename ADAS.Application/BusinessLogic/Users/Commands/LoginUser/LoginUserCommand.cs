using ADAS.Application.Common.Commands;
using MediatR;

namespace ADAS.Application.BusinessLogic.Users.Commands.LoginUser;

public class LoginUserCommand : BaseUserCommand, IRequest<bool>
{

}