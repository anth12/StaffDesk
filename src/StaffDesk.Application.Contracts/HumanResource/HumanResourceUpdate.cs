using System;
using StaffDesk.Domain;

namespace StaffDesk.Application.Contracts.HumanResource
{
	public class HumanResourceUpdate
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public ResourceStatus Status { get; set; }
		public string EmployeeNumber { get; set; }
		public int DepartmentId { get; set; }
	}
}
