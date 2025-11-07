using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Todo.Model
{
    [Table("Task")]
    public class Todo
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required, MaxLength(400)]
        public string TaskName { get; set; } =string.Empty;
        [Required]
        public int UserID { get; set; }
        [Required]
        public int StatusID { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        
    }
}

