using StaffDesk.Domain;

namespace StaffDesk.Application.Contracts.HumanResource
{
	public class HumanResourceQuery
	{
		public int Page { get; set; } = 1;

		public int? DepartmentId { get; set; }
		public ResourceStatus? Status { get; set; }
		public ResourceSortOrder SortOrder { get; set; }
	}
}
