using ADAS.Application.BusinessLogic.Bugs.Commands.CreateBugTicket;
using ADAS.Application.Models.Emails;
using ADAS.Domain.Entities;
using AutoMapper;

namespace ADAS.Application.BusinessLogic.Bugs.Profiles;

public class BugProfile : Profile
{
	public BugProfile()
	{
		CreateMap<BugTicket, BugReportViewModel>()
			.ForMember(model =>model.UserId, opt => opt.MapFrom(ticket => ticket.User.Id))
			.ForMember(model => model.UserEmail, opt => opt.MapFrom(ticket => ticket.User.Email))
			.ReverseMap();
		
		CreateMap<BugTicket,CreateBugTicketCommand>()
			.ReverseMap();
	}
}