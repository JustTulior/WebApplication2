using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Shops
    {
    public class ShopsConfiguration: IEntityTypeConfiguration<Shops>
    {
        public void Configure(EntityTypeBuilder<Shops> builder)
        {
            builder.HasKey(x => x.id);
        }
    }
}
