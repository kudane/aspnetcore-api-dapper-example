namespace App.Data.Repository.Repositories.Base
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper.Contrib.Extensions;

    abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected IDbConnection Connection { get; }

        public BaseRepository(IDbConnection connection) => 
            (Connection) = (connection);

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

        public IEnumerable<TEntity> SelectAll() => 
            Connection.GetAll<TEntity>();

        public async ValueTask<TEntity> FindOrNull(int key) => 
            await Connection.GetAsync<TEntity>(key);
    }
}
