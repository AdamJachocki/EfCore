using EfCoreHello.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace EfCoreHello.Services
{
    public class UserService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public UserService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddOrUpdateUser(User data)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            
            dbContext.Users.Update(data);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.Users.ToListAsync();
        }
    }
}
