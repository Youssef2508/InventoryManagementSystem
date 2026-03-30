namespace Project_2.Helpers
{
    public class Pager
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public int Skip => (PageNumber - 1) * PageSize;
    }
}
