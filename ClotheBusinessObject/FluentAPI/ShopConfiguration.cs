using ClotheBusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClotheBusinessObject.FluentAPI
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.ToTable("Shop");
            builder.HasKey(x => x.ShopID);
            builder.Property(x => x.ShopName).IsRequired();
            builder.Property(x => x.ShopAddress).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.OpenTime).IsRequired();
            builder.Property(x => x.CloseTime).IsRequired();
            builder.HasMany(x => x.Accounts).WithOne(x => x.Shop).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Clothes).WithOne(x => x.Shop).OnDelete(DeleteBehavior.NoAction);





        }
    }
}
