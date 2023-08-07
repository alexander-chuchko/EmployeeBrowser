using BSATask.Common.Interface;
using BSATask.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using BSATask.DAL.Entities;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        //api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var recivedUser = await _userService.GetUserByIdAsync(id);

            if (recivedUser is null)
            {
                return NotFound();
            }

            return Ok(recivedUser);
        }

        //api/users
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserDTO userDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var addedUser = await _userService.AddUserAsync(userDTO);
                if (addedUser is not null)
                {
                    return CreatedAtAction(nameof(Add), new { id = addedUser.Id }, addedUser);
                }
                else
                {
                    return BadRequest("Failed to add the team.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recivedUser = await _userService.GetUserByIdAsync(id);

            if (recivedUser is null)
            {
                return NotFound();
            }
            
            if (id <= 1)
            {
                return BadRequest();
            }

            await _userService.DeleteUserAsync(id);

            return NoContent();
        }

        //api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] UserDTO userDTO)
        {
            var recivedUser = await _userService.GetUserByIdAsync(id);

            if (recivedUser is null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            await _userService.UpdateUserAsync(userDTO); 

            return Ok(recivedUser);
        }
    }
}
