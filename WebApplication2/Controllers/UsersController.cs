using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using WebApplication2.Extentions;
using Microsoft.AspNetCore.Server.HttpSys;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    //[Authorize]
    [Route("    [controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersEntity>>> Get()
        {
            var users = await _usersRepository.Get();
            return Ok(users);
        }

        [HttpGet("id")]
        public async Task<ActionResult<UsersEntity>> GetById(Guid id)   
        {
            var user = await _usersRepository.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpPut]
        public async Task<ActionResult<UsersEntity>> Put(UsersEntity user)
        {
            if (user == null)
                return BadRequest();

            var existingUser = await _usersRepository.GetById(user.id);
            if (existingUser == null)
                return NotFound();

            await _usersRepository.Update(user);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UsersEntity>> CreateUser(UsersEntity user)
        {

            user.id = Guid.NewGuid();
            var createdUser = await _usersRepository.Add(user);
            return Ok(createdUser);

        }
        [HttpDelete]
        public async Task<ActionResult<UsersEntity>> Delete(Guid id)
        {
            var user = await _usersRepository.GetById(id);
            if (user != null)
            {
                await _usersRepository.Delete(id);
                return Ok(user);
            }
            else
                return BadRequest();
        }
    }
}
