using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetUsers()
        {
            return Ok(await _context.UserModels.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var user = await _context.UserModels.FindAsync(id);
            if (user == null)
                return BadRequest("User not found.");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser(UserModel user)
        {
            _context.UserModels.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.UserModels.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<UserModel>> UpdateUser(UserModel request)
        {
            var dbuser = await _context.UserModels.FindAsync(request.id);
            if (dbuser == null)
                return BadRequest("User not found.");
            dbuser.username = request.username;
            dbuser.first_name = request.first_name;
            dbuser.last_name = request.last_name;
            dbuser.email = request.email;
            await _context.SaveChangesAsync();
            return Ok(await _context.UserModels.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserModel>>> DeleteUser(int id)
        {
            var dbuser = await _context.UserModels.FindAsync(id);
            if (dbuser == null)
                return BadRequest("User not found.");
            _context.UserModels.Remove(dbuser);
            await _context.SaveChangesAsync();
            return Ok(await _context.UserModels.ToListAsync());
        }
    }
}
