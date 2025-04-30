using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication2.Shops;
using WebApplication2;

namespace WebApplication2
{
    public class DatabaseContext: DbContext
    {

        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<ShopsEntity> Shops { get; set; } = null!;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
