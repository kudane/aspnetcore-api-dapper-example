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
        private readonly IMovieRepository movieRepository;
        private readonly IGenreRepository genreRepository;

        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            this.movieRepository = movieRepository;
            this.genreRepository = genreRepository;
        }

        public IEnumerable<Movie> GetAll() => this.movieRepository.SelectAll();

        public async Task<Option<Movie, Error>> Get(int key) =>
            (await this.movieRepository.FindOrNull(key))
                .SomeWhen<Movie, Error>(movie => movie != null, $"Movie {key}, Not found.");


        public async Task<Option<IEnumerable<Movie>, Error>> GetByGenreKey(int key, Pager pager) =>
            await (await genreRepository.FindOrNull(key))
                .SomeWhen<Genre, Error>(genre => genre != null, $"Genre {key}, Not found.")
                .MapAsync(async _ => await this.movieRepository.SelectByGenreKey(key, pager));
                
    }
}
