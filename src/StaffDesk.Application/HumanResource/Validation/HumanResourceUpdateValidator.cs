using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StaffDesk.Application.Contracts.HumanResource;
using StaffDesk.Infrastructure.Contracts;

namespace StaffDesk.Application.HumanResource.Validation
{
	internal class HumanResourceUpdateValidator : AbstractValidator<HumanResourceUpdate>
	{
		private readonly IDataContext _dataContext;

		public HumanResourceUpdateValidator(IConfiguration configuration, IDataContext dataContext)
		{
			_dataContext = dataContext;
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
				.NotEmpty()
				.MustAsync(BeAValidDepartment).WithMessage("Must be a valid Department");
		}

		private Task<bool> BeAValidDepartment(int id, CancellationToken cancellationToken)
		{
			var result = _dataContext.Department.AnyAsync(d => d.Id == id, cancellationToken);

			return result;
		}
	}
}
