using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StaffDesk.Application.Contracts.HumanResource;
using StaffDesk.Domain;
using StaffDesk.Domain.Pagination;
using StaffDesk.Infrastructure.Contracts;

namespace StaffDesk.Application.Services
{
	internal class HumanResourceService : IHumanResourceService
	{
		private readonly IDataContext _dataContext;
		private readonly int _pageSize;

		public HumanResourceService(IDataContext dataContext, IConfiguration _configuration)
		{
			_dataContext = dataContext;
			int.TryParse(_configuration["TotalResultsPerPage"], out _pageSize);
		}

		public async Task<PagedCollection<HumanResource>> QueryAsync(HumanResourceQuery request)
		{
			IQueryable<HumanResource> query = _dataContext.HumanResource
				.Include(r=> r.Department);

			query = ApplyQueryFilters(request, query);

			query = ApplyQueryOrdering(query, request.SortOrder);

			var totalItems = query.Count();
			var results = await query.Skip((request.Page- 1) * _pageSize).Take(_pageSize).ToListAsync();

			return new PagedCollection<HumanResource>(
				items: results,
				totalItems: totalItems,
				currentPage: request.Page,
				pageSize: _pageSize);
		}

		private static IQueryable<HumanResource> ApplyQueryFilters(HumanResourceQuery request, IQueryable<HumanResource> query)
		{
			if (request.DepartmentId != null)
			{
				query = query.Where(r => r.Department.Id == request.DepartmentId);
			}

			if (request.Status != null)
			{
				query = query.Where(r => r.Status == request.Status);
			}

			return query;
		}

		private static IQueryable<HumanResource> ApplyQueryOrdering(IQueryable<HumanResource> query, ResourceSortOrder sortOrder)
		{
			switch (sortOrder)
			{
				case ResourceSortOrder.NameAscending:
					return query.OrderBy(r => r.LastName);

				case ResourceSortOrder.NameDescending:
					return query.OrderByDescending(r => r.LastName);

				case ResourceSortOrder.DateOfBirthAscending:
					return query.OrderBy(r => r.DateOfBirth);

				case ResourceSortOrder.DateOfBirthDescending:
					return query.OrderByDescending(r => r.DateOfBirth);

				default:
					throw new NotSupportedException($"Order is not supported for {sortOrder}");
			}
		}
	}
}
