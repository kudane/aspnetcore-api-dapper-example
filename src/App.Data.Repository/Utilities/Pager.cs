namespace App.Data.Repository.Utilities
{
    public readonly struct Pager
    {
        internal int PageSize { get;}

        internal int PageNumber { get;}

        public Pager(int size, int number)
        {
            PageSize = size;
            PageNumber = number;
        }
    }
}
