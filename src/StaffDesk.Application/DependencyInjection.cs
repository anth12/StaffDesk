using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using StaffDesk.Application.Services;
using StaffDesk.Application.Validation;
using StaffDesk.Domain;

namespace StaffDesk.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			// Services
			services.AddTransient<IDepartmentService, DepartmentService>();
			services.AddTransient<IHumanResourceService, HumanResourceService>();

			// Validators
			services.AddSingleton<IValidator<HumanResource>, HumanResourceValidator>();

			return services;
		}
	}
}
