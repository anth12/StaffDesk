using FluentValidation;
using StaffDesk.Domain;

namespace StaffDesk.Application.Validation
{
	public class HumanResourceValidator : AbstractValidator<HumanResource>
	{
		public HumanResourceValidator()
		{
			RuleFor(r => r.FirstName).NotEmpty();
			RuleFor(r => r.LastName).NotEmpty();
			RuleFor(r => r.EmailAddress).NotEmpty().EmailAddress();
			RuleFor(r => r.Status).IsInEnum();
			RuleFor(r => r.EmployeeNumber).NotEmpty();
		}
	}
}
