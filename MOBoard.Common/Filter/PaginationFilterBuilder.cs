namespace MOBoard.Common.Filter
{
    public class PaginationFilterBuilder
    {
        public static PaginationFilter Build(PaginationFilter paginationFilter)
        {
            if (paginationFilter.ElementsPerPage <= 0)
            {
                paginationFilter.ElementsPerPage = 20;
            }

            if (paginationFilter.Page <= 0)
            {
                paginationFilter.Page = 1;
            }
            return new PaginationFilter(paginationFilter.ElementsPerPage, paginationFilter.Page);
        }
    }
}