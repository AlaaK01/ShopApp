using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.shared.Models;
using ShopApp.shared.Services;




namespace ShopApp.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _usersServices;
        public UsersController (IUsersServices usersServices) => _usersServices = usersServices;

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = await _usersServices.GetUsers();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _usersServices.GetUserById(id);
            return (user == null) ? NotFound($"User with Id = {id} not found") : Ok(user);
        }

        // POST api/<UserssController>
        [HttpPost]
        public async Task<ActionResult<User>> Crate([FromForm] User user)
        {
            var newUser = _usersServices.CreateAsync(user.UserName, user.Password, user.Email);
            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] User updateUser)
        {
            var ExistingUser = await _usersServices.GetUserById(id);
            if (ExistingUser is null) return NotFound($"User with Id = {id} not found");
            await _usersServices.Update(id, updateUser);
            return Ok(ExistingUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var ExistingUser = await _usersServices.GetUserById(id);
            if (ExistingUser is null) return NotFound($"User with Id = {id} not found");
            await _usersServices.Remove(id);
            return Ok(ExistingUser);
        }
    }
}
