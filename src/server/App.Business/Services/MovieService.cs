namespace App.Business.Services
{
    using App.Business.Interfaces;
    using App.Data.Entities.Shared;
    using App.Data.Entities.Shared.Extensions;
    using App.Data.Repository.Interfaces;
    using App.Data.Repository.Produces;
    using Optional;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository) =>
            (_movieRepository) = (movieRepository);

        public IEnumerable<Movie> GetAll() => _movieRepository.SelectAll();

        public async Task<Option<Movie, Error>> GetAsync(int key) =>
            (await _movieRepository.GetOrNullAsync(key))
                .SomeWhen<Movie, Error>(movie => movie.IsNotNull(), $"Movie {key}, Not found.");

        public ref PageResult<Movie> FindMoviesByGenre(int genreKey, int pageSize = 20, int pageNumber = 1) =>
            ref _movieRepository.SelectByGenreKey(genreKey, pageSize, pageNumber);
    }
}
