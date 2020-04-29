namespace App.Data.Repository.Utilities
{
    public readonly struct Pager
    {
        internal int PageSize { get;}

        internal int PageNumber { get;}

        public Pager(int pageSize, int pageNumber)
        {
            this.PageSize = pageSize;
            this.PageNumber = pageNumber;
        }
    }
}
