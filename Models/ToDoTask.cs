
namespace WpfShowcaseCenter.Models
{
    public class ToDoTask
    {
        public int Priority { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }

        public ToDoTask(int priority, string? description, DateTime? deadline)
        {
            Priority = priority;
            Description = description;
            Deadline = deadline;
        }
    }
}
