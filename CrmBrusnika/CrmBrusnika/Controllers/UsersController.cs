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
    }
}
