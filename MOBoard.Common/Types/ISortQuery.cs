namespace MOBoard.Common.Types
{
    public interface ISortQuery
    {
        string SortBy { get; set; }
        bool IsSortOrderAscending { get; set; }
        int Offset { get; set; }
        int ResultsPerPage { get; set; }
    }
}