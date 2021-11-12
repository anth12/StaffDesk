using System.Threading.Tasks;
using StaffDesk.Domain;

namespace StaffDesk.Application.Services
{
	public interface IDepartmentService
	{
		Task<Department[]> GetAllAsync();
	}
}