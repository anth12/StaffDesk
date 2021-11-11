using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffDesk.Domain;

namespace StaffDesk.Infrastructure.Contracts
{
	public interface IDataContext
	{
		DbSet<HumanResource> HumanResource { get; set; }
		DbSet<Department> Department { get; set; }

		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
