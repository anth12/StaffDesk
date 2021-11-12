using System.Threading.Tasks;
using StaffDesk.Domain;
using StaffDesk.Domain.Pagination;

namespace StaffDesk.Infrastructure.Contracts
{
	public interface IHumanResourceRepository
	{
		Task<PagedCollection<HumanResource>> QueryAsync(int? departmentId, ResourceStatus sortOrder);
	}
}