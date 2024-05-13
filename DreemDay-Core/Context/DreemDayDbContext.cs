using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Context
{
    public class DreemDayDbContext : DbContext
    {
        public DreemDayDbContext(DreemDayDbContext options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Service> Services  { get; set; }
        public virtual DbSet<ServiceProvider> ServiceProviders  { get; set; }
        public virtual DbSet<Login> Logins  { get; set; }
        public virtual DbSet<Category> Categories  { get; set; }

    }
}
