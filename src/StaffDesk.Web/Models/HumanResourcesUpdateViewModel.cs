using Microsoft.AspNetCore.Mvc.Rendering;
using StaffDesk.Application.Contracts.HumanResource;

namespace StaffDesk.Web.Models
{
	public class HumanResourcesUpdateViewModel
	{
		public HumanResourceUpdate HumanResource { get; set; }

		public SelectListItem[] DepartmentsOptions { get; set; }
		public SelectListItem[] StatusOptions { get; set; }
	}
}
