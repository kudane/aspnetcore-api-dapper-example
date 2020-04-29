namespace App.Data.Repository.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericRepository<TEntitie>
    {
        bool CreateOrFailed(TEntitie entitie, out long identity);

        bool UpdateOrFailed(TEntitie entitie);

        bool DeleteOrFailed(TEntitie entitie);

        IEnumerable<TEntitie> SelectAll();

        Task<TEntitie> FindOrNull(int key);
    }
}
