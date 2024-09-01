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
  public class ContactEntityConfugration : IEntityTypeConfiguration<Contact>
  {
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.FullName).IsRequired();
      builder.Property(x => x.Email).IsRequired();
      builder.Property(x => x.Message).IsRequired();
      builder.Property(x => x.Subject).IsRequired();
      //Realtion

    }
  }
  
}
