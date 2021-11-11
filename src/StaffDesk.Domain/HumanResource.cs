using System;

namespace StaffDesk.Domain
{
	public class HumanResource
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public ResourceStatus Status { get; set; }
		public string EmployeeNumber { get; set; }
		public Department Department { get; set; }
	}
}
