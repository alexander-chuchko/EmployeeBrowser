using BSATask.Common.Interface;
using Microsoft.AspNetCore.Mvc;
using BSATask.Common.DTO;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        //api/projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAll()
        {
            return Ok(await _projectService.GetProjectsAsync());
        }

        //api/projects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var recivedProject = await _projectService.GetProjectByIdAsync(id);

            if (recivedProject is null)
            {
                return NotFound();
            }

            return Ok(recivedProject);
        }

        //api/projects
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProjectDTO projectDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var addedProjectDTO = await _projectService.AddProjectAsync(projectDTO);

                if (addedProjectDTO is not null)
                {
                    return CreatedAtAction(nameof(Add), new { id = addedProjectDTO.Id }, addedProjectDTO);
                }
                else
                {
                    return BadRequest("Failed to add the project.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //api/projects/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var receivedProject = await _projectService.GetProjectByIdAsync(id);

            if (receivedProject is null)
            {
                return NotFound();
            }
            if (id < 1)
            {
                return BadRequest();
            }

            await _projectService.DeleteProjectAsync(id);

            return NoContent();
        }


        //api/projects/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProjectDTO projectDTO)
        {
            var receivedProject = await _projectService.GetProjectByIdAsync(id);

            if (receivedProject is null)
            {
                return NotFound($"Project with ID {id} not found.");
            }

            await _projectService.UpdateProjectAsync(projectDTO);

            return Ok(projectDTO);
        }
    }
}
