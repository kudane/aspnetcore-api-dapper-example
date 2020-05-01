namespace App.Data.Repository.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericRepository<TEntity>
    {
        bool CreateOrFailed(TEntity entitie, out long identity);

        bool UpdateOrFailed(TEntity entitie);

        bool DeleteOrFailed(TEntity entitie);

        IEnumerable<TEntity> SelectAll();

        ValueTask<TEntity> FindOrNull(int key);
    }
}
