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
    public class ClotheConfiguration : IEntityTypeConfiguration<Clothe>
    {
        public void Configure(EntityTypeBuilder<Clothe> builder)
        {
            builder.ToTable("Clothe");
            builder.HasKey(x => x.ClotheID);
            builder.Property(x => x.ClotheName).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Rent).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
