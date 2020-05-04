namespace App.Web.Api.Controllers.Base
{
    using App.Business;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Error(Error error) =>
            new BadRequestObjectResult(error);

        protected IActionResult NotFound(Error error) =>
            new NotFoundObjectResult(error);
    }
}
