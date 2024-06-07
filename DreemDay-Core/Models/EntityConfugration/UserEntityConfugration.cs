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
    public class UserEntityConfugration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreationDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(15);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(15);
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(15);
            //Relation
            builder.HasOne<Login>().WithOne().HasForeignKey<Login>(x => x.UserId);
            builder.HasOne<ServiceProvider>().WithOne().HasForeignKey<ServiceProvider>(x => x.UserId);
            builder.HasMany<Order>().WithOne().HasForeignKey(x => x.UserId);
            builder.HasMany<Cart>().WithOne().HasForeignKey(x => x.UserId);



        }
    }
}
