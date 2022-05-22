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
            var dbuser = _context.UserModels.AsNoTracking().Where(x => x.id == request.id).FirstOrDefault();

            if (string.IsNullOrEmpty(request.username))
            {
                request.username = dbuser.username;
            }
            if (string.IsNullOrEmpty(request.first_name))
            {
                request.first_name = dbuser.first_name;
            }
            if (string.IsNullOrEmpty(request.last_name))
            {
                request.last_name = dbuser.last_name;
            }
            if (string.IsNullOrEmpty(request.email))
            {
                request.email = dbuser.email;
            }

            _context.UserModels.Update(request);
            await _context.SaveChangesAsync();

            return Ok(await _context.UserModels.Where(x => x.id == request.id).FirstOrDefaultAsync());
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
