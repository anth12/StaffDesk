using System;

namespace StaffDesk.Domain
{
	public class HumanResource
	{
		public HumanResource(int id, string firstName, string lastName, string emailAddress, DateTime? dateOfBirth, ResourceStatus status, string employeeNumber, Department department)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			EmailAddress = emailAddress;
			DateOfBirth = dateOfBirth;
			Status = status;
			EmployeeNumber = employeeNumber;
			Department = department;
		}

		public int Id { get; }
		public string FirstName { get; }
		public string LastName { get; }
		public string EmailAddress { get; }
		public DateTime? DateOfBirth { get; }
		public ResourceStatus Status { get; }
		public string EmployeeNumber { get; }
		public Department Department { get; }
	}
}
