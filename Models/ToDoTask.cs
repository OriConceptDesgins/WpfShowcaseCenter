
namespace WpfShowcaseCenter.Models
{
    public class ToDoTask
    {
        public int Priority { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsCompleted { get; set; } = false;

        public ToDoTask(int priority, string? description, DateTime? deadline)
        {
            Priority = priority;
            Description = description;
            Deadline = deadline;
        }

        public override string ToString()
        {
            return $"{Priority}: {Description} (Deadline: {Deadline?.ToString("d")}, Completed: {IsCompleted})";
        }
    }
}
