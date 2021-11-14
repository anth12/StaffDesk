using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaffDesk.Application.Contracts.Department;
using StaffDesk.Application.Contracts.HumanResource;
using StaffDesk.Application.Department;
using StaffDesk.Domain;
using StaffDesk.Web.Models;

namespace StaffDesk.Web.Controllers
{
	[Route("human-resources")]
	public class HumanResourceController : Controller
	{
		private readonly IHumanResourceService _humanResourceService;
		private readonly IHumanResourceSearchService _humanResourceSearchService;
		private readonly IDepartmentService _departmentService;

		public HumanResourceController(IHumanResourceService humanResourceService, IHumanResourceSearchService humanResourceSearchService, IDepartmentService departmentService)
		{
			_humanResourceService = humanResourceService;
			_humanResourceSearchService = humanResourceSearchService;
			_departmentService = departmentService;
		}

		#region Read 

		public async Task<IActionResult> Index(HumanResourceQuery query)
		{
			var resources = await _humanResourceSearchService.QueryAsync(query);

			var departmentListItems = await GetDepartmentSelectListItemsAsync();
			var statusLisItems = GetStatusSelectListItems();

			var viewModel = new HumanResourcesListViewModel
			{
				HumanResources = resources,
				DepartmentsOptions = departmentListItems,
				StatusOptions = statusLisItems,
				Query = query
			};
			return View(viewModel);
		}

		#endregion

		#region Create
		
		[Route("create")]
		public async Task<IActionResult> Create()
		{
			return await UpdateView(new HumanResourceUpdate());
		}

		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> Create(HumanResourceUpdate humanResource)
		{
			if(!ModelState.IsValid)
				return await UpdateView(humanResource);

			await _humanResourceService.CrateOrUpdateAsync(humanResource);

			return RedirectToAction(nameof(Index));
		}

		#endregion

		#region Update

		[Route("{id}")]
		public async Task<IActionResult> Update(int id)
		{
			var humanResource = await _humanResourceService.GetAsync(id);

			if (humanResource == null)
				return NotFound();

			var humanResourceUpdate = new HumanResourceUpdate
			{
				Id = humanResource.Id,
				FirstName = humanResource.FirstName,
				LastName = humanResource.LastName,
				EmailAddress = humanResource.EmailAddress,
				DateOfBirth = humanResource.DateOfBirth,
				Status = humanResource.Status,
				EmployeeNumber = humanResource.EmployeeNumber,
				DepartmentId = humanResource.Department?.Id ?? 0,
			};

			return await UpdateView(humanResourceUpdate);
		}

		[HttpPost]
		[Route("{id}")]
		public async Task<IActionResult> Update(int id, HumanResourceUpdate humanResource)
		{
			if (!ModelState.IsValid)
				return await UpdateView(humanResource);

			await _humanResourceService.CrateOrUpdateAsync(humanResource);

			return RedirectToAction(nameof(Index));
		}

		#endregion
		
		private async Task<IActionResult> UpdateView(HumanResourceUpdate humanResource)
		{
			var departmentListItems = await GetDepartmentSelectListItemsAsync();
			var statusLisItems = GetStatusSelectListItems();

			var viewModel = new HumanResourcesUpdateViewModel
			{
				HumanResource = humanResource,
				DepartmentsOptions = departmentListItems,
				StatusOptions = statusLisItems
			};

			return View("Update", viewModel);
		}

		private async Task<SelectListItem[]> GetDepartmentSelectListItemsAsync()
		{
			var departments = await _departmentService.GetAllAsync();

			var departmentListItems = departments
				.Select(d => new SelectListItem(d.Name, d.Id.ToString()))
				.ToArray();

			return departmentListItems;
		}

		private SelectListItem[] GetStatusSelectListItems()
		{
			var statusLisItems = Enum.GetValues<ResourceStatus>()
				.Select(e => new SelectListItem(e.ToString(), e.ToString()))
				.ToArray();

			return statusLisItems;
		}
	}
}
