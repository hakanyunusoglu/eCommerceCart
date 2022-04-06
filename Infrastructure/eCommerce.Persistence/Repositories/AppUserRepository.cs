using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace eCommerce.Persistence.Repositories
{
    public class AppUserRepository<T> : IAppUserRepository<T> where T : class, new()
    {
        private readonly eCommerceDbContext eCommerceDbContext;

        public AppUserRepository(eCommerceDbContext eCommerceDbContext)
        {
            this.eCommerceDbContext = eCommerceDbContext;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        { 
            var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public async Task<List<AppUser>> GetAll()
        {
            return await this.eCommerceDbContext.Set<AppUser>().AsNoTracking().ToListAsync();
        }

        public async Task<AppUser> GetByUsername(string data)
        {
            return await this.eCommerceDbContext.Set<AppUser>().FirstOrDefaultAsync(x => x.Username == data);
        }
        public async Task<bool> VerifyPassowrd(string password,string username, byte[] passwordHash, byte[] passwordSalt)
        {

            var checkuser = await GetByUsername(username);
            var hmac = new HMACSHA512(checkuser.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != checkuser.PasswordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
