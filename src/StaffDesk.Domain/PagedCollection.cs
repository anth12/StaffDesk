using System.Collections.Generic;

namespace StaffDesk.Domain
{
	public class PagedCollection<T>
	{
		public PagedCollection(IEnumerable<T> items, int totalItems, int totalPages, int currentPage, int pageSize)
		{
			Items = items;
			TotalItems = totalItems;
			TotalPages = totalPages;
			CurrentPage = currentPage;
			PageSize = pageSize;
		}

		public IEnumerable<T> Items { get; }

		public int TotalItems { get; }
		public int CurrentPage { get; }
		public int PageSize { get; }
		public int TotalPages { get; }
	}
}
