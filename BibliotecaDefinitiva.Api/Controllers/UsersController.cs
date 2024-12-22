using Microsoft.AspNetCore.Mvc;
using BibliotecaDefinitiva.Domain.Entities;
using BibliotecaDefinitiva.Application.Services;

namespace BibliotecaDefinitiva.Api.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService) => _userService = userService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
            => Ok(await _userService.GetAllUsers());

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
            => Ok(await _userService.GetUserById(id));

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            var result = await _userService.AddUser(user);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest();
            await _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}