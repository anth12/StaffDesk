using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffDesk.Domain;
using StaffDesk.Infrastructure.Contracts;

namespace StaffDesk.Application.Services
{
	internal class DepartmentService : IDepartmentService
	{
		private readonly IDataContext _dataContext;

		public DepartmentService(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}
		
		public Task<Department[]> GetAllAsync()
		{
			return _dataContext.Department.ToArrayAsync();
		}
	}
}
