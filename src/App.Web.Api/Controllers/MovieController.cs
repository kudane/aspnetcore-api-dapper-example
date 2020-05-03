namespace App.Web.Api.Controllers
{
    using App.Business.Interfaces;
    using App.Web.Api.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MovieController : ApiController
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service) => (_service) = (service);

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetAll());

        [HttpGet("{key}")]
        public async Task<IActionResult> Get(int key) =>
            (await _service.Get(key)).Match(movie => Ok(movie), NotFound);
    }
}
