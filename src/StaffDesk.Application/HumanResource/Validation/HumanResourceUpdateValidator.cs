using System;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using StaffDesk.Application.Contracts.HumanResource;

namespace StaffDesk.Application.HumanResource.Validation
{
	public class HumanResourceUpdateValidator : AbstractValidator<HumanResourceUpdate>
	{
		public HumanResourceUpdateValidator(IConfiguration configuration)
		{
			int minimumAgeYears = int.Parse(configuration["MinimumAgeYears"]);

			RuleFor(r => r.FirstName)
				.NotEmpty().MaximumLength(255);
			
			RuleFor(r => r.LastName)
				.NotEmpty().MaximumLength(255);
			
			RuleFor(r => r.EmailAddress)
				.NotEmpty().EmailAddress().MaximumLength(500);
			
			RuleFor(r => r.Status)
				.IsInEnum();
			
			RuleFor(r => r.EmployeeNumber)
				.NotEmpty().MaximumLength(20);
			
			RuleFor(r => r.DateOfBirth)
				.LessThanOrEqualTo(_=> DateTime.UtcNow.AddYears(-minimumAgeYears))
				.WithMessage($"Resource must be at least {minimumAgeYears} years of age.");

			RuleFor(r => r.DepartmentId)
				.NotEmpty(); // TODO validate Department exists
		}
	}
}
