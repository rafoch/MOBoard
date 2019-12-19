using System.Linq;
using MOBoard.Common.Filter;

namespace MOBoard.Common.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<TSource> SkipWithPagination<TSource>(this IQueryable<TSource> source,
            PaginationFilter pagination)
        {
            return source.Skip((pagination.Page * pagination.ElementsPerPage) - pagination.ElementsPerPage);
        }
    }
}