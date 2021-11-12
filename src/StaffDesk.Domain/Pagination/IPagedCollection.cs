
namespace StaffDesk.Domain.Pagination
{
	public interface IPagedCollection
	{
		int TotalItems { get; }
		int CurrentPage { get; }
		int PageSize { get; }
		int TotalPages { get; }
	}
}