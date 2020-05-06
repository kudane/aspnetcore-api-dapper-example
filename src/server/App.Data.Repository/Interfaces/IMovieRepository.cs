namespace App.Data.Repository.Interfaces
{
    using App.Data.Entities.Shared;
    using App.Data.Repository.Interfaces.Base;
    using App.Data.Repository.Produces;

    public interface IMovieRepository: IBaseRepository<Movie>
    {
        ref PageResult<Movie> SelectByGenreKey(int key, int pageSize, int pageNumber);
    }
}
