using DreemDay_Core.Models.Entity;
using DreemDay_Core.Models.EntityConfugration;
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
        public DreemDayDbContext(DbContextOptions<DreemDayDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderEntityConfugration());
            modelBuilder.ApplyConfiguration(new UserEntityConfugration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfugration());
            modelBuilder.ApplyConfiguration(new LoginEntityConfugration());
            modelBuilder.ApplyConfiguration(new ServiceEntityConfugration());
            modelBuilder.ApplyConfiguration(new ServiceProviderEntityConfugration());
            modelBuilder.ApplyConfiguration(new CartEntityConfugration());
            modelBuilder.ApplyConfiguration(new CartItemEntityConfugration());
            modelBuilder.ApplyConfiguration(new WishListEntityConfugration());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Service> Services  { get; set; }
        public virtual DbSet<ServiceProvider> ServiceProviders  { get; set; }
        public virtual DbSet<Login> Logins  { get; set; }
        public virtual DbSet<Category> Categories  { get; set; }
        public virtual DbSet<Cart> Carts  { get; set; }
        public virtual DbSet<CartItem> CartItems   { get; set; }
        public virtual DbSet<WishList> WishLists   { get; set; }

    }
}
