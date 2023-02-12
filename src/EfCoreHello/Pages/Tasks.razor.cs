using EfCoreHello.Models.Db;
using EfCoreHello.Services;
using EfCoreHello.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EfCoreHello.Pages
{
    public class TasksPage : ComponentBase
    {
        [Inject]
        public UserService UserService { get; set; }

        [Inject]
        public TaskService TaskService { get; set; }
        protected List<UserViewModel> Users { get; set; } = new();
        protected List<TaskViewModel> Tasks { get; set; } = new();

        protected bool ShowTaskEditor { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadUsers();
            await LoadTasks();

            ToDoItem item = new ToDoItem
            {
                Title = "asd",
                Description = "bla"
            };
            await TaskService.AddOrUpdateTask(item);
        }

        private async Task LoadUsers()
        {
            var users = await UserService.GetAll();

            foreach (var u in users)
            {
                Users.Add(new UserViewModel
                {
                    Id = u.Id,
                    Name = u.Name
                });
            }
        }

        private async Task LoadTasks()
        {
            var tasks = await TaskService.GetItems();
            foreach(var t in tasks)
            {
                Tasks.Add(new TaskViewModel
                {
                    Id = t.Id,
                    Description = t.Description,
                    EndDate = t.EndDate,
                    Owner = new UserViewModel
                    {
                        Id = t.OwnerId
                    },
                    StartDate= t.StartDate,
                    Status= t.Status,
                    Title= t.Title
                });
            }
        }

        protected void AddTaskHandler(MouseEventArgs args)
        {
            ShowTaskEditor = true;
        }

        protected async Task TaskAddedHandler(TaskViewModel vm)
        {
            var item = new ToDoItem
            {
                Title = vm.Title,
                Description = vm.Description,
                OwnerId = vm.Owner.Id,
                Status = vm.Status
            };

            await TaskService.AddOrUpdateTask(item);
        }
    }
}
