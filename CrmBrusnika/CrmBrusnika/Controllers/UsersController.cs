using Microsoft.AspNetCore.Mvc;

namespace CrmBrusnika.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new[]
            {
                new { Name = "vanya"},
                new { Name = "ilya"}
            };
            return Ok(users);
        }

        [Route("/v2")]
        [HttpGet]
        public IActionResult GetUsers2()
        {
            var users = new[]
            {
                new { Name = "123"},
                new { Name = "2314423"}
            };
            return Ok(users);
        }
    }
}
