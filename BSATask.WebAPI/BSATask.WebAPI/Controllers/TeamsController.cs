using BSATask.Common.Interface;
using BSATask.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService; 
        }

        //api/teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDTO>>> GetAll()
        {
            return Ok(await _teamService.GetTeamsAsync());
        }

        //api/teams/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDTO>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var recivedTeam = await _teamService.GetTeamByIdAsync(id);

            if (recivedTeam is null)
            {
                return NotFound();
            }

            return Ok(recivedTeam);
        }

        //api/teams
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeamDTO teamDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var addedTeam = await _teamService.AddTeamAsync(teamDTO);
                if (addedTeam is not null)
                {
                    return CreatedAtAction(nameof(Add), new { id = addedTeam.Id }, addedTeam);
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

        //api/teams/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var receivedTeam = await _teamService.GetTeamByIdAsync(id);

            if (receivedTeam is null)
            {
                return NotFound();
            }
            if (id <= 1)
            {
                return BadRequest();
            }

            await _teamService.DeleteTeamAsync(id);

            return NoContent();
        }

        //api/teams/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] TeamDTO teamDTO)
        { 
            var receivedTeam = await _teamService.GetTeamByIdAsync(id);

            if (receivedTeam is null)
            {
                return NotFound($"Team with ID {id} not found.");
            }
             await _teamService.UpdateTeamAsync(teamDTO);

            return Ok(teamDTO);
        }
    }
}
