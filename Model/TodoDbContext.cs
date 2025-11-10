using Microsoft.EntityFrameworkCore;

namespace Todo.Model
{
    public class TodoDbContext:DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        } 
       public DbSet<TodoItem> TodoItems { get; set; }
    }
}
