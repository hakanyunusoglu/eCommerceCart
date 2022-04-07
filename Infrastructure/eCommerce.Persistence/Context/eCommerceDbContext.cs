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
                 ID = new Guid("c557e1ce-b638-11ec-b909-0242ac120002"),
                    CreatedDate = DateTime.Now,
                    Title = "Computer",
                    Description = "Electronic Equipment"
            },
            new Category(){
                ID = new Guid("db9572ee-b638-11ec-b909-0242ac120002"),
                    CreatedDate = DateTime.Now,
                    Title = "Tablet",
                    Description = "Electronic Small Equipment"
            },
            new Category(){
                 ID = new Guid("e275007a-b638-11ec-b909-0242ac120002"),
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
                ID = new Guid("415220a0-b639-11ec-b909-0242ac120002"),
                CreatedDate = DateTime.Now,
                Image = "productimg/03.jpg",
                Description = "Xiaomi Smart Phone",
                Title = "Smart Phone",
                categoryID = new Guid("e275007a-b638-11ec-b909-0242ac120002")
            },
            new Product()
            {
                Name = "Apple Tablet",
                ID = new Guid("5186d10a-b639-11ec-b909-0242ac120002"),
                CreatedDate = DateTime.Now,
                Image = "productimg/02.jpg",
                Description = "Apple new generation",
                Title = "Tablet",
                categoryID = new Guid("db9572ee-b638-11ec-b909-0242ac120002")
            },
            new Product()
            {
                Name = "Asus Notebook",
                ID = new Guid("5d80aa30-b639-11ec-b909-0242ac120002"),
                CreatedDate = DateTime.Now,
                Image = "productimg/01.jpg",
                Description = "i7 notebook",
                Title = "Notebook",
                categoryID = new Guid("c557e1ce-b638-11ec-b909-0242ac120002")
            }};
            builder.Entity<Product>().HasData(productList);
        }

        private void SeedSellerList(ModelBuilder builder)
        {
            List<SellerList> sellerList = new List<SellerList>() { new SellerList()
            {
                 CreatedDate = DateTime.Now,
                 ID = new Guid("6571cb0c-b639-11ec-b909-0242ac120002"),
                 Price = 4999,
                 Quantity = 10,
                 productID = new Guid("415220a0-b639-11ec-b909-0242ac120002")
            },
            new SellerList(){
                ID= new Guid("6ad5a76c-b639-11ec-b909-0242ac120002"),
                CreatedDate= DateTime.Now,
                Price = 3856,
                Quantity= 5,
                productID = new Guid("5186d10a-b639-11ec-b909-0242ac120002")
             },
            new SellerList(){
             CreatedDate = DateTime.Now,
             ID= new Guid("713aeebe-b639-11ec-b909-0242ac120002"),
             Price = 8999,
             Quantity = 16,
             productID = new Guid("5d80aa30-b639-11ec-b909-0242ac120002")
            } };
            builder.Entity<SellerList>().HasData(sellerList);
        }

    }
}
