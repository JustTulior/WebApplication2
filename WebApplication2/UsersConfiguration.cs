using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WebApplication2
{
    public class UsersConfiguration: IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder) 
        {
            builder.HasKey(x => x.id);
        }
    }
}
