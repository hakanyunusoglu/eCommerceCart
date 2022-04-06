using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Repositories
{
    public interface IAppUserRepository<T> where T : class, new()
    {
        Task<List<AppUser>> GetAll();
        Task<AppUser> GetByUsername(string data);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordsalt);
        Task<bool> VerifyPassowrd(string password,string username, byte[] passwordHash, byte[] passwordSalt);

    }
}
