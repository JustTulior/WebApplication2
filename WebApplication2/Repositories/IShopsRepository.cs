
namespace WebApplication2.Repositories
{
    public interface IShopsRepository
    {
        Task<ShopsEntity> Create(ShopsEntity shopsEntity);
        Task Create(string name, string address);
        Task Delete(string name);
        Task<List<ShopsEntity>> Get();
        Task<ShopsEntity?> GetById(int id);
        Task Update(ShopsEntity shopsEntity);
    }
}