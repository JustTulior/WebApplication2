using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Configurations
{
    public class ShopConfiguration: IEntityTypeConfiguration<ShopsEntity>
    {
        public void Configure (EntityTypeBuilder<ShopsEntity> builder)
        {
            builder
                .HasKey(x => x.id);
                
        }

    }
}
