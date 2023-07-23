namespace Talabat.Core.Specifications
{
    public class ProductSpecParams
    {
        #region Pagination
        private const int MaxPageSize = 10;
        public int PageIndex { get; set; } = 1;
        private int pageSize = 5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        #endregion

        private string? search;
        public string? Search
        {
            get { return search; }
            set { search = value.ToLower(); }
        }

        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
    }
}
