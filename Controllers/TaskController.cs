using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Model;
using System.Linq;

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

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _context.TodoItems.Where(t => !t.IsDeleted).ToList();
            return Ok(tasks);
        }


        [HttpPost]
        public IActionResult SaveTasks([FromBody] TodoItem task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.TodoItems.Add(task);
            _context.SaveChanges();
            return Ok(task);
        }


        [HttpPut]
        public IActionResult UpdateTask([FromBody] TodoItem task)
        {
            var record = _context.TodoItems.Find(task.TaskID);
            if (record == null)
                return NotFound(new { status = "Error", message = "Task not found." });

            record.TaskName = task.TaskName;
            record.StatusID = task.StatusID;
            record.IsDeleted = task.IsDeleted;
            _context.SaveChanges();
            return Ok(record);
        }


 

        [HttpDelete("{id}")]


        public IActionResult DeleteTaskById(int id)
        {
            var record = _context.TodoItems.Find(id);
            if (record == null)
                return NotFound(new { status = "Error", message = "Task not found." });

            record.IsDeleted = true;
            _context.SaveChanges();
            return Ok(new { status = "Deleted", id });
        }


    }
}




 






