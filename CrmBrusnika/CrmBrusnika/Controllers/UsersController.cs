using CrmBrusnika.Context;
using CrmBrusnika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Controllers
{
    [Route("api/users/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersContext _context;
        
        public UsersController(UsersContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get-users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> CreateUser(User user)
        {
            var newUser = new User(user.Email);
            var u = await _context.Users.AddAsync(newUser);

            await _context.SaveChangesAsync();

            var users = GetUsers();

            return Ok(u);
        }
    }
}
