using Domain.Model.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // To Store string And Return Enum
            builder.Property(o => o.Status)
                   .HasConversion(ost => ost.ToString(), osts => (OrderStatus)Enum.Parse(typeof(OrderStatus), osts));

            builder.Property(o => o.SubTotal)
                .HasColumnType("decimal(18,2)");

            // To Owns Address Not A Table

            builder.OwnsOne(o => o.ShippingAddress, sp => sp.WithOwner());

            builder.HasOne(o => o.deliveryMethod)
                   .WithMany()
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
