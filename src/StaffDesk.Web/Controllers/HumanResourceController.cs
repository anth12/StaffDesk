using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaffDesk.Application.Contracts.HumanResource;
using StaffDesk.Application.Services;
using StaffDesk.Domain;
using StaffDesk.Web.Models;

namespace StaffDesk.Web.Controllers
{
	[Route("human-resources")]
	public class HumanResourceController : Controller
	{
		private readonly IHumanResourceService _humanResourceService;
		private readonly IDepartmentService _departmentService;

		public HumanResourceController(IHumanResourceService humanResourceService, IDepartmentService departmentService)
		{
			_humanResourceService = humanResourceService;
			_departmentService = departmentService;
		}

		public async Task<IActionResult> Index(HumanResourceQuery query)
		{
			var resources = await _humanResourceService.QueryAsync(query);
			var departments = await _departmentService.GetAllAsync();

			var departmentListItems = departments
				.Select(d => new SelectListItem(d.Name, d.Id.ToString()))
				.ToArray();

			var statusLisItems = Enum.GetValues<ResourceStatus>()
				.Select(e => new SelectListItem(e.ToString(), e.ToString()))
				.ToArray();

			var viewModel = new HumanResourcesListViewModel
			{
				HumanResources = resources,
				DepartmentsOptions = departmentListItems,
				StatusOptions = statusLisItems,
				Query = query
			};
			return View(viewModel);
		}

		[Route("{id}")]
		public IActionResult Edit(int id)
		{
			return View();
		}
	}
}
