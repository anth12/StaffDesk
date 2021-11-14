using System.Threading.Tasks;

namespace StaffDesk.Application.Contracts.HumanResource
{
	public interface IHumanResourceService
	{
		Task<Domain.HumanResource> GetAsync(int id);

		Task<Domain.HumanResource> CrateOrUpdateAsync(HumanResourceUpdate request);
	}
}