using System.Collections.Generic;
using System.Threading.Tasks;
using StaffDesk.Domain;

namespace StaffDesk.Infrastructure.Contracts
{
	public interface IDepartmentRepository
	{
		Task<IEnumerable<Department>> GetAllAsync();
	}
}