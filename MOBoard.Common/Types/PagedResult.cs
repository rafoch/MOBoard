using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MOBoard.Common.Extensions;

namespace MOBoard.Common.Types
{
    public class PagedResult<T> : PagedResultBase
    {
        protected PagedResult()
        {
            Items = Enumerable.Empty<T>();
        }

        protected PagedResult(
            IReadOnlyCollection<T> items,
            int totalPages,
            long totalResults)
            : base(totalPages, totalResults)
        {
            Items = items;
        }

        public static PagedResult<T> Empty => new PagedResult<T>();

        public IEnumerable<T> Items { get; }

        public bool IsEmpty => Items == null || !Items.Any();

        public bool IsNotEmpty => !IsEmpty;

        public static PagedResult<T> Create(
            IReadOnlyCollection<T> items,
            int totalPages,
            long totalResults) =>
            new PagedResult<T>(items, totalPages, totalResults);

        public static PagedResult<T> From(PagedResultBase result, IEnumerable<T> items) =>
            new PagedResult<T>(
                items.ToReadOnly(),
                result.TotalPages,
                result.TotalResults);

        public static async Task<PagedResult<TResult>> CreateAsync<TResult>(IQueryable<TResult> queryable, ISortQuery query)
        {
            var totalResults = queryable.Count();
            var resultsPerPage = query.ResultsPerPage == 0 ? 8 : query.ResultsPerPage;
            var totalPages = (int)Math.Ceiling((decimal)totalResults / resultsPerPage);
            totalPages = Math.Max(totalPages, 1);

            if (!query.SortBy.IsNullOrWhiteSpace())
            {
                queryable = queryable.OrderBy(query.SortBy, query.IsSortOrderAscending);
            }

            var results = await queryable
                .Skip(query.Offset)
                .Take(resultsPerPage)
                .ToListAsync();

            return new PagedResult<TResult>(results, totalPages, totalResults);
        }
    }
}