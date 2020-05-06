namespace Backend.Repository.Repositories.Base
{
    using Dapper.Contrib.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    internal abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected IDbConnection Connection { get; }

        public BaseRepository(IDbConnection connection) => (Connection) = (connection);

        #region Create, Update, Delete
        public bool CreateOrFailed(TEntity entitie, out long identity)
        {
            bool state = false;
            identity = 0;
            using var tx = Connection.BeginTransaction();
            try
            {
                identity = Connection.Insert(entitie, tx);
                tx.Commit();
                state = true;
            }
            catch
            {
                tx.Rollback();
            }

            return state;
        }

        public bool UpdateOrFailed(TEntity entitie)
        {
            bool state = false;
            using var tx = Connection.BeginTransaction();
            try
            {
                Connection.Update(entitie, tx);
                tx.Commit();
                state = true;
            }
            catch
            {
                tx.Rollback();
            }

            return state;
        }

        public bool DeleteOrFailed(TEntity entitie)
        {
            bool state = false;
            using var tx = Connection.BeginTransaction();
            try
            {
                Connection.Delete(entitie, tx);
                tx.Commit();
                state = true;
            }
            catch
            {
                tx.Rollback();
            }

            return state;
        }
        #endregion

        #region SelectAll, GetAsync
        public IEnumerable<TEntity> SelectAll() => Connection.GetAll<TEntity>();

        public async Task<TEntity> GetOrNullAsync(int key) => await Connection.GetAsync<TEntity>(key);
        #endregion

        #region Action
        public async Task<TAction> DbActionAsync<TAction>(Func<IDbConnection, Task<TAction>> action) =>
            await action(Connection);
        #endregion
    }
}
