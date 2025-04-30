
namespace WebApplication2.Repositories
{
    public interface IUsersRepository
    {
        Task<UsersEntity> Add(UsersEntity users);
        Task<List<UsersEntity>> Get();
        Task<UsersEntity?> GetByFirstName(string login);
        Task<UsersEntity?> GetById(Guid id);
        //Task<List<UsersEntity>> GetByPage(int page, int pageSize);
        Task<UsersEntity?> Update(UsersEntity user);

        Task Delete(Guid id);
    }
}