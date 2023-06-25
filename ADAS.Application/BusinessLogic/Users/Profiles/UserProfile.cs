﻿
using ADAS.Application.BusinessLogic.Users.Commands.RegisterUser;
using ADAS.Domain.Entities;
using AutoMapper;

namespace ADAS.Application.BusinessLogic.Users.Profiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<RegisterUserCommand, User>()
			.ForMember(u => u.IsActive, opt => opt.MapFrom(c => true));
	}
}