namespace MOBoard.Common.Types
{
    public abstract class PagedResultBase
    {
        public int TotalPages { get; }
        public long TotalResults { get; }

        protected PagedResultBase()
        {
        }

        protected PagedResultBase(int totalPages, long totalResults)
        {
            TotalPages = totalPages;
            TotalResults = totalResults;
        }
    }
}