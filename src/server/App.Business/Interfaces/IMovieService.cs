namespace App.Business.Interfaces
{
    using App.Data.Repository.Entities;
    using App.Data.Repository.Produces;
    using Optional;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();

        Task<Option<Movie, Error>> Get(int key);

        ref PageResult<Movie> GetByGenreKey(int key, int pageSize, int pageNumber);
    }
}
