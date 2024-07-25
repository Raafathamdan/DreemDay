using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Models.EntityConfugration
{
    public class CartItemEntityConfugration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ServiceId).IsRequired();
            builder.Property(x => x.CartId).IsRequired();

            //Relation
            builder.HasOne<Cart>().WithMany().HasForeignKey(x => x.CartId);
            builder.HasOne<Service>().WithMany().HasForeignKey(x => x.ServiceId);


        }
    }
}
