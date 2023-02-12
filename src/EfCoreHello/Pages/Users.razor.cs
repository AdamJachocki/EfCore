using EfCoreHello.Models.Db;
using EfCoreHello.Services;
using EfCoreHello.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EfCoreHello.Pages
{
    public class UsersPage: ComponentBase
    {
        [Inject]
        public UserService UserService { get; set; }
        protected bool ShowUserEditor { get; set; }
        protected UserViewModel UserData { get; set; } = new();
        protected void AddUserClick(MouseEventArgs args)
        {
            ShowUserEditor = true;
        }

        protected async Task OnUpdateUser(UserViewModel user)
        {
            User dbUser = new User
            {
                Id = user.Id,
                Name = user.Name
            };

            await UserService.AddOrUpdateUser(dbUser);
            ShowUserEditor = false;
        }
    }
}
