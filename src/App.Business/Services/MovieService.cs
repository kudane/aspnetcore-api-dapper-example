namespace App.Business.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using App.Business.Interfaces;
    using App.Data.Repository.Entities;
    using App.Data.Repository.Extensions;
    using App.Data.Repository.Interfaces;
    using App.Data.Repository.Utilities;
    using Optional;
    using Optional.Async.Extensions;

    internal class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository) =>
            (_movieRepository) = (movieRepository);

        public IEnumerable<Movie> GetAll() => _movieRepository.SelectAll();

        public async Task<Option<Movie, Error>> Get(int key) =>
            (await _movieRepository.FindOrNull(key))
                .SomeWhen<Movie, Error>(movie => movie.IsNotNull(), $"Movie {key}, Not found.");

        public async Task<IEnumerable<Movie>> GetByGenreKey(int key, int pageSize = 20, int pageNumber = 1) =>
            await _movieRepository.SelectByGenreKey(key, new Pager(pageSize, pageNumber));
    }
}
