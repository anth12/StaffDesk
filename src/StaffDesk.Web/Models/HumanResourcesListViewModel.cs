using Microsoft.AspNetCore.Mvc.Rendering;
using StaffDesk.Application.Contracts.HumanResource;
using StaffDesk.Domain;
using StaffDesk.Domain.Pagination;

namespace StaffDesk.Web.Models
{
	public class HumanResourcesListViewModel
	{
		public PagedCollection<HumanResource> HumanResources { get; set; }
		
		public SelectListItem[] DepartmentsOptions { get; set; }
		public SelectListItem[] StatusOptions { get; set; }

		public HumanResourceQuery Query { get; set; }
	}
}
