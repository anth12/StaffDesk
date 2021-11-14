using System.Threading.Tasks;
using StaffDesk.Domain.Pagination;

namespace StaffDesk.Application.Contracts.HumanResource
{
	public interface IHumanResourceSearchService
	{
		Task<PagedCollection<Domain.HumanResource>> QueryAsync(HumanResourceQuery request);
	}
}