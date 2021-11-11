using System.Threading.Tasks;
using StaffDesk.Domain;

namespace StaffDesk.Infrastructure.Contracts
{
	public interface IHumanResourceRepository
	{
		Task<PagedCollection<HumanResource>> QueryAsync(int? departmentId, ResourceStatus sortOrder);
	}
}