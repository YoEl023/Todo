using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Model;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TaskController(TodoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _context.TodoItems.ToList();
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult SaveTasks(Task task)
        {
            _context.TodoItems.Add(task);
            _context.SaveChanges();
            return Ok(task);
        }

        [HttpPut]
        public IActionResult UpdateTasks(Task task)
        {
            var record = _context.TodoItems.Find(Task.TaskID);
            if (record == null)
            {
                var notFoundResponse = new
                {
                    status = "Error",
                    Message = "Task not Found."
                };
                return NotFound(notFoundResponse);
            } else
            {
                record.TaskName = task.TaskName;
                record.
                return Ok(task);

            }
                
            
        }
    }
}
