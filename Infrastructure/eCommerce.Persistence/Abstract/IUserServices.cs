using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Abstract
{
    public interface IUserServices
    {
        Task<List<AppUser>> GetAll();
        Task<AppUser> GetByUsername(string data);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordsalt);
        Task<bool> VerifyPassowrd(string password, string username, byte[] passwordHash, byte[] passwordSalt);
    }
}
