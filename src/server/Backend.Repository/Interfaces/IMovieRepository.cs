namespace Backend.Repository.Interfaces
{
    using Backend.Repository.Interfaces.Base;
    using Domain.Entity;
    using Domain.Entity.Produces;

    public interface IMovieRepository: IBaseRepository<Movie>
    {
        ref PageResult<Movie> SelectByGenreKey(int key, int pageSize, int pageNumber);
    }
}
