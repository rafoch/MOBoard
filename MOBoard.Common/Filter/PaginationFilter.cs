namespace MOBoard.Common.Filter
{
    public class PaginationFilter
    {
        public PaginationFilter(int paginationFilterElementsPerPage,int paginationFilterPage)
        {
            ElementsPerPage = paginationFilterElementsPerPage;
            Page = paginationFilterPage;
        }

        public PaginationFilter()
        {
            
        }
        public int ElementsPerPage { get; set; }
        public int Page { get; set; }
    }
}