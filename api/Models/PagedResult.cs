namespace API.Services
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Results { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public PagedResult(IEnumerable<T> results, int pageIndex, int pageSize, int totalCount)
        {
            Results = results;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
    }
}