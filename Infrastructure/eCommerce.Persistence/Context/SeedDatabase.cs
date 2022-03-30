using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Context
{
    public class SeedDatabase
    {
        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context is eCommerceDbContext)
                {
                    eCommerceDbContext _context = context as eCommerceDbContext;
                    if (_context.Users.Count() == 0)
                    {
                        _context.Users.AddRange(Users);
                    }
                    if (_context.Categories.Count() == 0)
                    {
                        _context.Categories.AddRange(Categories);
                    }
                }
                context.SaveChanges();
            }
        }
        public static void CreatePasswordHash(out byte[] passwordHash, out byte[] passwordSalt)
        {
            string password = "123456";
            var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public static byte[] GetHash()
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(out passwordHash, out passwordSalt);
            return passwordHash;
        }
        public static byte[] GetSalt()
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(out passwordHash, out passwordSalt);
            return passwordSalt;
        }
        private static AppUser[] Users = {
            new AppUser
            {
                ID = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Email = "hakanyunusoglu93@gmail.com",
                Username = "hakan",
                PasswordSalt =GetSalt().ToString(),
                PasswordHash = GetHash().ToString(),
                userInfo = new AppUserInfo
                {
                     CreatedDate = DateTime.Now,
                     ID = Guid.NewGuid(),
                     Name = "Hakan",
                     Surname ="Yunusoğlu",
                     userAddress = new AppUserAddress
                       {
                           ID= Guid.NewGuid(),
                           City = "Istanbul",
                           Country = "Türkiye",
                           Street = "Hadımköy",
                           Number = "19",
                           CreatedDate = DateTime.Now
                       }
                }
            }
        };
        private static Category[] Categories = 
        {
            new Category
            {
                 ID = Guid.NewGuid(),
                  CreatedDate= DateTime.Now,
                   Description ="Elektronik Aletler",
                    Title = "Elektronik",
                     ProductList = new List<Product>
                     {
                         new Product 
                         {
                             ID = Guid.NewGuid(), 
                             Name = "Bilgisayar", 
                             Title ="Asus Notebook", 
                             Description ="i7 10. nesil", 
                             Image="productimg/01.jpg", 
                             CreatedDate = DateTime.Now,
                             SellerList = new List<SellerList>
                             {
                                  new SellerList
                                  {
                                       ID = Guid.NewGuid(),
                                       CreatedDate = DateTime.Now,
                                       Price = 4990,
                                       Quantity = 5
                                  },
                                  new SellerList
                                  {
                                       ID = Guid.NewGuid(),
                                       CreatedDate = DateTime.Now,
                                       Price = 3490,
                                       Quantity = 3
                                  }
                             }
                         },
                         new Product
                         {
                             ID = Guid.NewGuid(),
                             Name = "Tablet",
                             Title = "Apple Tablet",
                             Description = "9 inch",
                             Image="productimg/02.jpg",
                             CreatedDate = DateTime.Now,
                             SellerList= new List<SellerList>
                             {
                                 new SellerList
                                 {
                                      ID = Guid.NewGuid(),
                                      CreatedDate = DateTime.Now,
                                      Price = 1899,
                                      Quantity = 4
                                 },
                                 new SellerList
                                 {
                                     ID= Guid.NewGuid(),
                                     CreatedDate= DateTime.Now,
                                     Price = 2200,
                                     Quantity = 8
                                 }
                             }
                         }
                     }
            }
        };
    }
}
