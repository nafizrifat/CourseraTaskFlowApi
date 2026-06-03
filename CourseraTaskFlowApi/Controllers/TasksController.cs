using CourseraTaskFlowApi.Models;
using CourseraTaskFlowApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseraTaskFlowApi.Controllers
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

        [HttpGet]
        public ActionResult<List<TaskItem>> GetAllTasks()
        {
            return Ok(_taskService.GetAllTasks());
        }

        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetTaskById(int id)
        {
            TaskItem? task = _taskService.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskItem> CreateTask(TaskItem task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TaskItem createdTask = _taskService.CreateTask(task);

            return CreatedAtAction(
                nameof(GetTaskById),
                new { id = createdTask.Id },
                createdTask
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskItem updatedTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isUpdated = _taskService.UpdateTask(id, updatedTask);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            bool isDeleted = _taskService.DeleteTask(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}