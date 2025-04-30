using Microsoft.EntityFrameworkCore;
using WebApplication2;

namespace WebApplication2.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DatabaseContext _dbContext;
        public UsersRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }
        public async Task<List<UsersEntity>> Get()
        {
            return await _dbContext.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UsersEntity?> GetById(Guid id)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<UsersEntity?> GetByFirstName(string login)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.login == login);
        }

        public async Task<UsersEntity> Add(UsersEntity users)
        {
            await _dbContext.Users.AddAsync(users);
            await _dbContext.SaveChangesAsync();
            return users;
        }
        //public async Task<List<UsersEntity>> GetByPage(int page, int pageSize)
        //{
        //    return await _dbContext.Users
        //                .AsNoTracking()
        //                .Skip((page - 1) * pageSize)
        //                .Take(pageSize)
        //                .ToListAsync();
        //}

        public async Task<UsersEntity?> Update(UsersEntity user)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.id == user.id);
            if (existingUser == null)
                return null;

            // Обновляем нужные поля
            existingUser.login = user.login;
            existingUser.password = user.password;
            await _dbContext.SaveChangesAsync();
            return existingUser;
        }
        public async Task Delete(Guid id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.id == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
