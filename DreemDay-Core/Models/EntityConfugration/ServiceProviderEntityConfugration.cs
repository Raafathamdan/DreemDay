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
    public class ServiceProviderEntityConfugration : IEntityTypeConfiguration<ServiceProvider>
    {
        public void Configure(EntityTypeBuilder<ServiceProvider> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.ProfileImage).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(15);
            builder.HasCheckConstraint("CK_Phone_Format", "Phone LIKE '[0-9]%'");
            builder.Property(x => x.AdminName).IsRequired().HasMaxLength(50);

        }
    }
}
