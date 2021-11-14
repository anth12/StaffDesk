using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using StaffDesk.Application.Contracts.Department;
using StaffDesk.Application.Contracts.HumanResource;
using StaffDesk.Application.Department;
using StaffDesk.Application.HumanResource;
using StaffDesk.Application.HumanResource.Validation;

namespace StaffDesk.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			// Services
			services.AddTransient<IDepartmentService, DepartmentService>();
			services.AddTransient<IHumanResourceService, HumanResourceService>();
			services.AddTransient<IHumanResourceSearchService, HumanResourceSearchService>();

			// Validators
			services.AddSingleton<IValidator<HumanResourceUpdate>, HumanResourceUpdateValidator>();

			return services;
		}
	}
}
