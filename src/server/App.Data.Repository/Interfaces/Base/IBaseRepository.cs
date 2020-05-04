namespace App.Data.Repository.Interfaces.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    public interface IBaseRepository<TEntity>
    {
        abstract bool CreateOrFailed(TEntity entitie, out long identity);

        bool UpdateOrFailed(TEntity entitie);

        bool DeleteOrFailed(TEntity entitie);

        IEnumerable<TEntity> SelectAll();

        Task<TEntity> FindOrNull(int key);

        Task<TAction> DbAction<TAction>(Func<IDbConnection, Task<TAction>> action);
    }
}
