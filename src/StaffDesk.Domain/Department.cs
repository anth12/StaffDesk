
namespace StaffDesk.Domain
{
	public class Department
	{
		public Department(int id, int name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; }
		public int Name { get; }
	}
}
