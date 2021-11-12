using System;
using System.Collections.Generic;

namespace StaffDesk.Domain.Pagination
{
	public class PagedCollection<T> : IPagedCollection
	{
		public PagedCollection(IEnumerable<T> items, int totalItems, int currentPage, int pageSize)
		{
			Items = items;
			TotalItems = totalItems;
			CurrentPage = currentPage;
			PageSize = pageSize;

			TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
		}

		public IEnumerable<T> Items { get; }

		public int TotalItems { get; }
		public int CurrentPage { get; }
		public int PageSize { get; }
		public int TotalPages { get; }
	}
}
