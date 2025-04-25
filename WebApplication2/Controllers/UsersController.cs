using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using WebApplication2.Extentions;
using Microsoft.AspNetCore.Server.HttpSys;

namespace WebApplication2.Controllers
{
   // [Authorize]
    [Route("    [controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        DatabaseContext db;
        public UsersController(DatabaseContext context)
        {
            db = context;
            if (db.Users.Any())
            {
                db.Users.Add(new Users
                {
                    id = Guid.NewGuid(),    
                    login = "Ivan",
                    password = "12345"
                });
            }    
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            return await db.Users.AsNoTracking().ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(Guid id)
        {
            Users? user = await db.Users.FirstOrDefaultAsync(x => x.id == id);
            if (user == null) return NotFound();
            return new ObjectResult(user);
        }
        [HttpPost]

        public async Task<ActionResult<Users>> Put (Users users)
        {
            if (users == null) return BadRequest();
            if (!db.Users.Any(x => x.id == users.id))
            {
                return NotFound();
            }
            db.Update(users);
            await db.SaveChangesAsync();
            return Ok(users);
        }
    }
}
