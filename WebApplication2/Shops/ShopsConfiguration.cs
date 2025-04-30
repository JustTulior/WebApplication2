using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Shops
    {
    public class ShopsConfiguration: IEntityTypeConfiguration<ShopsEntity>
    {
        public void Configure(EntityTypeBuilder<ShopsEntity> builder)
        {
            builder.HasKey(x => x.id);
        }
    }
}
