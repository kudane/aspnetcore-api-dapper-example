namespace App.Data.Repository.Interfaces
{
    using App.Data.Repository.Entities;
    using App.Data.Repository.Interfaces.Base;
    using App.Data.Repository.Utilities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMovieRepository: IBaseRepository<Movie>
    {
        ValueTask<IEnumerable<Movie>> SelectByGenreKey(int key, Pager pager);
    }
}
