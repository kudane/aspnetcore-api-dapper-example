namespace App.Web.Api.Controllers
{
    using App.Business.Interfaces;
    using App.Data.Repository.Utilities;
    using App.Web.Api.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MovieController : ApiController
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetAll());

        [HttpGet("{key}")]
        public async Task<IActionResult> Get(int key) => 
            (await _service.Get(key))
                .Match(movie => Ok(movie), NotFound);

        [HttpGet]
        [Route("genre")]
        [Route("genre/{key}")]
        public async Task<IActionResult> GetByGenreKey(int key = 1, [FromQuery] int pageSize = 20, int pageNumber = 1)
        {
            var pager = new Pager(pageSize, pageNumber);
            var result = await _service.GetByGenreKey(key, pager);
            return result.Match(movies => Ok(movies), NotFound);
        }
    }
}
