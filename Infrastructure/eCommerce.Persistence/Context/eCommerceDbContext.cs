using eCommerce.Domain.Entities;
using eCommerce.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Context
{
    public class eCommerceDbContext : DbContext
    {
        public eCommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppUserAddress> UsersAddresses { get; set; }
        public DbSet<AppUserInfo> UsersInfo { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SellerList> SellerLists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}
