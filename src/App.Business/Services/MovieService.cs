namespace App.Business.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using App.Business.Interfaces;
    using App.Data.Repository.Entities;
    using App.Data.Repository.Interfaces;
    using App.Data.Repository.Utilities;
    using Optional;
    using Optional.Async.Extensions;

    internal class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;

        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository) =>
            (_movieRepository, _genreRepository) = (movieRepository, genreRepository);

        public IEnumerable<Movie> GetAll() => _movieRepository.SelectAll();

        public async Task<Option<Movie, Error>> Get(int key) =>
            (await _movieRepository.FindOrNull(key))
                .SomeWhen<Movie, Error>(movie => movie != null, $"Movie {key}, Not found.");

        public async Task<Option<IEnumerable<Movie>, Error>> GetByGenreKey(int key, Pager pager) =>
            await (await _genreRepository.FindOrNull(key))
                .SomeWhen<Genre, Error>(genre => genre != null, $"Genre {key}, Not found.")
                .MapAsync(async _ => await _movieRepository.SelectByGenreKey(key, pager));
                
    }
}
