using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Models.EntityConfugration
{
    public class PaymentEntityConfugration : IEntityTypeConfiguration<Payment>
    {

        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.IsDeleted).HasDefaultValue(false);
            builder.Property(x=>x.CardHolder).IsRequired();
            builder.Property(x=>x.CardNumber).IsRequired();
            builder.Property(x=>x.Code).IsRequired();
            builder.Property(x=>x.ExpireDate).IsRequired();
            builder.Property(x=>x.Balance).IsRequired();


        }
    }
}