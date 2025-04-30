using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WebApplication2
{
    public class UsersConfiguration: IEntityTypeConfiguration<UsersEntity>
    {
        public void Configure(EntityTypeBuilder<UsersEntity> builder) 
        {
            builder.HasKey(x => x.id);
        }
    }
}
