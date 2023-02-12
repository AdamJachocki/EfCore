using EfCoreHello.Models.Db;
using System.ComponentModel.DataAnnotations;

namespace EfCoreHello.ViewModels
{
    public class TaskViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public UserViewModel Owner { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public ToDoItemStatus Status { get; set; } = ToDoItemStatus.NotStarted;
        public DateTimeOffset? EndDate { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
