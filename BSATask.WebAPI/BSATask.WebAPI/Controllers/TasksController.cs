using BSATask.Common.Interface;
using BSATask.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using BSATask.Common.Sevices;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;   
        }

        //api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAll()
        {
            return Ok(await _taskService.GetTasksAsync());
        }

        //api/tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var recivedTask = await _taskService.GetTaskByIdAsync(id);

            if (recivedTask is null)
            {
                return NotFound();
            }

            return Ok(recivedTask);
        }

        //api/tasks
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TaskDTO taskDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var addedTask = await _taskService.AddTaskAsync(taskDTO);
                if (addedTask is not null)
                {
                    return CreatedAtAction(nameof(Add), new { id = addedTask.Id }, addedTask);
                }
                else
                {
                    return BadRequest("Failed to add the task.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recivedTask = await _taskService.GetTaskByIdAsync(id);

            if (recivedTask is null)
            {
                return NotFound();
            }
            if (id < 1)
            {
                return BadRequest();
            }
            await _taskService.DeleteTaskAsync(id);

            return NoContent();
        }

        //api/tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskDTO taskDTO)
        {
            var receivedTask = await _taskService.GetTaskByIdAsync(id);

            if (receivedTask is null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            await _taskService.UpdateTaskAsync(taskDTO);

            return Ok(taskDTO);
        }
    }
}