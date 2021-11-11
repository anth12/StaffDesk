using Microsoft.EntityFrameworkCore;
using StaffDesk.Domain;
using StaffDesk.Infrastructure.Contracts;

namespace StaffDesk.Infrastructure.Database
{
	internal class DataContext : DbContext, IDataContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
			
		}

		public virtual DbSet<HumanResource> HumanResource { get; set; }
		public virtual DbSet<Department> Department { get; set; }
		

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Department>(entity =>
			{
				entity.HasKey(e => e.Id);
				
				entity.Property(e => e.Name);
			});

			modelBuilder.Entity<HumanResource>(entity =>
			{
				entity.HasKey(e => e.Id);
				
				entity.Property(e => e.FirstName);
				entity.Property(e => e.LastName);
				entity.Property(e => e.EmailAddress);
				entity.Property(e => e.DateOfBirth);
				entity.Property(e => e.Status);
				entity.Property(e => e.EmployeeNumber);

				entity.HasOne(d => d.Department)
					.WithMany()
					.HasForeignKey("DepartmentId");
			});
		}
    }
}
