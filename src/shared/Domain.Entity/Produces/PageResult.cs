namespace Domain.Entity.Produces
{
    using System.Collections.Generic;

    public struct PageResult<TEntity>
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public List<TEntity> Items { get; set; }

        public int TotalItems { get; set; }
    }
}
