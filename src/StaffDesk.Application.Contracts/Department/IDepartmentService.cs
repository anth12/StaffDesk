using System.Threading.Tasks;

namespace StaffDesk.Application.Contracts.Department
{
	public interface IDepartmentService
	{
		Task<Domain.Department[]> GetAllAsync();
	}
}