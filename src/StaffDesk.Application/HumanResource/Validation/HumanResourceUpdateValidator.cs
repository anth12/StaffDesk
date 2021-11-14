using FluentValidation;
using StaffDesk.Application.Contracts.HumanResource;

namespace StaffDesk.Application.Validation
{
	public class HumanResourceUpdateValidator : AbstractValidator<HumanResourceUpdate>
	{
		public HumanResourceUpdateValidator()
		{
			RuleFor(r => r.FirstName).NotEmpty();
			RuleFor(r => r.LastName).NotEmpty();
			RuleFor(r => r.EmailAddress).NotEmpty().EmailAddress();
			RuleFor(r => r.Status).IsInEnum();
			RuleFor(r => r.EmployeeNumber).NotEmpty();
			RuleFor(r => r.DepartmentId).NotEmpty(); // TODO validate Department exists
		}
	}
}
