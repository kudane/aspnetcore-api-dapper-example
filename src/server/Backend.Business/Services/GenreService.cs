namespace Backend.Business.Services
{
    using Backend.Business.Interfaces;
    using Backend.Repository.Interfaces;
    using Domain.Entity;
    using Domain.Entity.Extensions;
    using Optional;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository) =>
            (_genreRepository) = (genreRepository);

        public IEnumerable<Genre> GetAll() => _genreRepository.SelectAll();

        public async Task<Option<Genre, Error>> GetAsync(int key) =>
            (await _genreRepository.GetOrNullAsync(key))
                .SomeWhen<Genre, Error>(genre => genre.IsNotNull(), $"Genre {key}, Not found.");
    }
}
