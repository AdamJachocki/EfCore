using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreHello.Models.Db
{
    public enum ToDoItemStatus
    {
        NotStarted,
        Running,
        Done
    }
    public class ToDoItem: BaseDbItem
    {
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public ToDoItemStatus Status { get; set; } = ToDoItemStatus.NotStarted;
        public DateTimeOffset? EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
