using System.Threading.Tasks;
using StaffDesk.Application.Contracts.HumanResource;
using StaffDesk.Domain;
using StaffDesk.Domain.Pagination;

namespace StaffDesk.Application.Services
{
	public interface IHumanResourceService
	{
		Task<PagedCollection<HumanResource>> QueryAsync(HumanResourceQuery request);
	}
}