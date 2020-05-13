namespace Backend.Business.Interfaces
{
    using Domain.Entity;
    using Domain.Entity.Produces;
    using Optional;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();

        Task<Option<Movie, Error>> GetAsync(int key);

        ref PageResult<Movie> FindMoviesByGenre(int genreKey, int pageSize, int pageNumber, string search = "");
    }
}
