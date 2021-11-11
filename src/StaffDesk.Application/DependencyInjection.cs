using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using StaffDesk.Application.Validation;
using StaffDesk.Domain;

namespace StaffDesk.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddSingleton<IValidator<HumanResource>, HumanResourceValidator>();

			return services;
		}
	}
}
