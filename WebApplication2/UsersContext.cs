using Microsoft.EntityFrameworkCore;
using WebApplication2;

namespace WebApplication2
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; } = null!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Users>()
        //     .HasData(
        //        new Users { id = Guid.NewGuid(), login = "Oleg", password = "322" },
        //        new Users { id = Guid.NewGuid(), login = "qwe", password = "123" }
        //        );

        //}
    }
}
