namespace App.Business.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using App.Data.Repository.Entities;
    using App.Data.Repository.Utilities;
    using Optional;

    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();

        Task<Option<Movie, Error>> Get(int key);

        Task<Option<IEnumerable<Movie>, Error>> GetByGenreKey(int key, Pager pager);
    }
}
