using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ADAS.Application.DIExtensions;

public static class ApplicationDIExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(Assembly.GetExecutingAssembly());
		services.AddMapping();
		return services;
	}

	public static IServiceCollection AddMapping(this IServiceCollection services)
	{
		var mapperConfig = new MapperConfiguration(mc => { mc.AddMaps(Assembly.GetExecutingAssembly()); });
		var mapper = mapperConfig.CreateMapper();
		services.AddSingleton(mapper);
		return services;
	}
}