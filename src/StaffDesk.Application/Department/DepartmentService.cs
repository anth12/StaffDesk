using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffDesk.Application.Contracts.Department;
using StaffDesk.Infrastructure.Contracts;

namespace StaffDesk.Application.Department
{
	internal class DepartmentService : IDepartmentService
	{
		private readonly IDataContext _dataContext;

		public DepartmentService(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}
		
		public Task<Domain.Department[]> GetAllAsync()
		{
			return _dataContext.Department.ToArrayAsync();
		}
	}
}
