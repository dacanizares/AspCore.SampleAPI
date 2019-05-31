using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Domain.Managers;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBehavior _behavior;

        private readonly IMapper _mapper;

        public UsersController(IUserBehavior behavior, IMapper mapper)
        {
            _behavior = behavior;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
        {
            return await _behavior.FindAllAsync();
        }

        [HttpGet("{username}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<User>> GetByUsernameAsync(string username)
        {
            var existingUser = await _behavior.FindByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }
            return existingUser;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<User>> CreateUserAsync(CreateUserCommand createUserCommand)
        {
            var user = _mapper.Map<User>(createUserCommand);
            await _behavior.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetByUsernameAsync), new { username = user.Username }, user);
        }

        [HttpPut("{username}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUserAsync(string username, UpdateUserCommand updateUserCommand)
        {
            var existingUser = await _behavior.FindByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }

            _mapper.Map(updateUserCommand, existingUser);
            await _behavior.UpdateUserAsync(existingUser);
            return NoContent();
        }

        [HttpDelete("{username}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUserAsync(string username)
        {
            var existingUser = await _behavior.FindByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _behavior.DeleteUserAsync(existingUser);
            return NoContent();
        }
    }
}
