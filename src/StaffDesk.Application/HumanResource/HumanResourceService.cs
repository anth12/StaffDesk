using System.Threading;
using System.Threading.Tasks;
using StaffDesk.Application.Contracts.HumanResource;
using StaffDesk.Infrastructure.Contracts;

namespace StaffDesk.Application.HumanResource
{
	internal class HumanResourceService : IHumanResourceService
	{
		private readonly IDataContext _dataContext;

		public HumanResourceService(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<Domain.HumanResource> GetAsync(int id)
		{
			var result = await _dataContext.HumanResource.FindAsync(id);

			return result;
		}

		public async Task<Domain.HumanResource> CrateOrUpdateAsync(HumanResourceUpdate request)
		{
			Domain.HumanResource entity;
			if (request.Id > 0)
			{
				entity = await _dataContext.HumanResource.FindAsync(request.Id);
			}
			else
			{
				entity = new Domain.HumanResource();
				_dataContext.HumanResource.Add(entity);
			}

			await MapToDomainAsync(request, entity);

			await _dataContext.SaveChangesAsync(CancellationToken.None);

			return entity;
		}

		public async Task MapToDomainAsync(HumanResourceUpdate request, Domain.HumanResource entity)
		{
			entity.Id = request.Id;
			entity.FirstName = request.FirstName;
			entity.LastName = request.LastName;
			entity.EmailAddress = request.EmailAddress;
			entity.DateOfBirth = request.DateOfBirth;
			entity.Status = request.Status;
			entity.EmployeeNumber = request.EmployeeNumber;

			var department = await _dataContext.Department.FindAsync(request.DepartmentId);
			entity.Department = department;
		}
	}
}
