namespace App.Web.Api.Controllers
{
    using App.Business.Interfaces;
    using App.Web.Api.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;
    using Optional.Async.Extensions;
    using System.Threading.Tasks;

    public class GenreController : ApiController
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public GenreController(IMovieService movieService, IGenreService genreService) => 
            (_movieService, _genreService) = (movieService, genreService);

        [HttpGet]
        public IActionResult Get() => Ok(_genreService.GetAll());

        [HttpGet("{key}")]
        public async Task<IActionResult> GetAsync(int key) =>
            (await _genreService.Get(key)).Match(genre => Ok(genre), NotFound);

        [HttpGet("{key}/movies")]
        public async Task<IActionResult> GetMovies(int key = 1, int pageSize = 20, int pageNumber = 1) =>
            (await _genreService.Get(key))
                .Map(_ => _movieService.GetByGenreKey(key, pageSize, pageNumber))
                .Match(movies => Ok(movies), NotFound);
    }
}