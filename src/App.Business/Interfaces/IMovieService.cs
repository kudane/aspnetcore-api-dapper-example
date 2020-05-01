namespace App.Business.Interfaces
{
    using App.Data.Repository.Entities;
    using Optional;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();

        ValueTask<Option<Movie, Error>> Get(int key);

        ValueTask<IEnumerable<Movie>> GetByGenreKey(int key, int pageSize, int pageNumber);
    }
}
