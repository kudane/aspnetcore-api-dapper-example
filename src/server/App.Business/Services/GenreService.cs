namespace App.Business.Services
{
    using App.Business.Interfaces;
    using App.Data.Entities.Shared;
    using App.Data.Entities.Shared.Extensions;
    using App.Data.Repository.Interfaces;
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
