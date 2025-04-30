using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Shops;

namespace WebApplication2.Repositories
{
    public class ShopsRepository : IShopsRepository
    {
        private readonly DatabaseContext _dbContext;

        public ShopsRepository(DatabaseContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<List<ShopsEntity>> Get()
        {
            return await _dbContext.Shops
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<ShopsEntity?> GetById(int id)
        {
            return await _dbContext.Shops
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);
        }
        public async Task Create(string name, string address)
        {
            var shop = new ShopsEntity
            {
                name = name,
                address = address
            };
            await _dbContext.Shops.AddAsync(shop);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(string name)
        {
            var shop = _dbContext.Shops.FirstOrDefault(x => x.name == name);
            if (shop != null)
            {
                _dbContext.Shops.Remove(shop);
                await _dbContext.SaveChangesAsync();
            }
        }
        public Task Update(ShopsEntity shopsEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<ShopsEntity> Create(ShopsEntity shopsEntity)
        {
            var shops = shopsEntity;
            await _dbContext.Shops.AddAsync(shopsEntity);
            await _dbContext.SaveChangesAsync();
            return shopsEntity;
        }
    }
}
