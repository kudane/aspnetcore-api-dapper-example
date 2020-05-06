namespace Backend.Repository.Interfaces
{
    using Backend.Repository.Interfaces.Base;
    using Domain.Entities;
    using Domain.Entities.Produces;

    public interface IMovieRepository: IBaseRepository<Movie>
    {
        ref PageResult<Movie> SelectByGenreKey(int key, int pageSize, int pageNumber);
    }
}
