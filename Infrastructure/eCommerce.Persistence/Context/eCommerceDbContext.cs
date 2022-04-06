using eCommerce.Domain.Entities;
using eCommerce.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        //public DbSet<AppUserAddress> UsersAddresses { get; set; }
        //public DbSet<AppUserInfo> UsersInfo { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SellerList> SellerLists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());
            base.OnModelCreating(modelBuilder);
            this.SeedUser(modelBuilder);
            this.SeedCategory(modelBuilder);
            this.SeedProduct(modelBuilder);
            this.SeedSellerList(modelBuilder);
        }
        private void SeedUser(ModelBuilder builder)
        {
            byte[] passwordHash, passwordSalt;
            string password = "123456";
            var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            AppUser user = new AppUser()
            {
                ID = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Username = "hakan",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            builder.Entity<AppUser>().HasData(user);
        }
        private void SeedCategory(ModelBuilder builder)
        {
            List<Category> categoryList = new List<Category>() { new Category()
            {
                 ID = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    Title = "Computer",
                    Description = "Electronic Equipment"
            },
            new Category(){
                ID = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    Title = "Tablet",
                    Description = "Electronic Small Equipment"
            },
            new Category(){
                 ID = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    Title = "Phone",
                    Description = "Electronic Smart Equipment"
            } };
            builder.Entity<Category>().HasData(categoryList);
        }
        private void SeedProduct(ModelBuilder builder)
        {
            List<Product> productList = new List<Product>() { new Product()
            {
                Name = "Mobile Phone",
                ID = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Image = "productimg/03.jpg",
                Description = "Xiaomi Smart Phone",
                Title = "Smart Phone"
            },
            new Product()
            {
                Name = "Apple Tablet",
                ID = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Image = "productimg/02.jpg",
                Description = "Apple new generation",
                Title = "Tablet"
            },
            new Product()
            {
                Name = "Asus Notebook",
                ID = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Image = "productimg/01.jpg",
                Description = "i7 notebook",
                Title = "Notebook",
            }};
            builder.Entity<Product>().HasData(productList);
        }

        private void SeedSellerList(ModelBuilder builder)
        {
            List<SellerList> sellerList = new List<SellerList>() { new SellerList()
            {
                 CreatedDate = DateTime.Now,
                 ID = Guid.NewGuid(),
                 Price = 4999,
                 Quantity = 10
            },
            new SellerList(){
                ID= Guid.NewGuid(),
                CreatedDate= DateTime.Now,
                Price = 3856,
                Quantity= 5
             },
            new SellerList(){
             CreatedDate = DateTime.Now,
             ID= Guid.NewGuid(),
             Price = 8999,
             Quantity = 16
            } };
            builder.Entity<SellerList>().HasData(sellerList);
        }

    }
}
