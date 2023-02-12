using EfCoreHello.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace EfCoreHello.Services
{
    public class TaskService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public TaskService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        public async Task AddOrUpdateTask(ToDoItem item)
        {
            User owner;
            using var ctx = _dbContextFactory.CreateDbContext();
            owner = await ctx.Users.FirstAsync();

            item.Owner = null;
            ctx.ToDoItems.Update(item);
            await ctx.SaveChangesAsync();




            
            //using var ctx = _dbContextFactory.CreateDbContext();

            //var task = await ctx.ToDoItems.Where(x => x.Status == ToDoItemStatus.NotStarted)
            //    .Include(x => x.Owner)
            //    .SingleAsync();
            //task.Status = ToDoItemStatus.Done;
            //await ctx.SaveChangesAsync();

            //if (item.Id == Guid.Empty)
            //    ctx.ToDoItems.Add(item);
            //else
            //    ctx.ToDoItems.Update(item);

            //await ctx.SaveChangesAsync();
        }

        public async Task<List<ToDoItem>> GetItems()
        {
            using var ctx = _dbContextFactory.CreateDbContext();

            var data = await ctx.ToDoItems
                .Include(x => x.Owner)
                .ToListAsync();

            return data;
        }
    }
}
