using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data.Configuration
{
    public class productConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.ProductBrands)
                .WithMany()
                .HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.ProductTypes)
               .WithMany()
               .HasForeignKey(p => p.TypeId);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(10,2)");
        }
    }
}
