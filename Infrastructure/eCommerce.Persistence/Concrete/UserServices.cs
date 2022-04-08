using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Concrete
{
    public class UserServices : IUserServices
    {
        private IAppUserRepository<AppUser> repo;
        public UserServices(IAppUserRepository<AppUser> _repo)
        {
            repo = _repo;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordsalt)
        {
           repo.CreatePasswordHash(password, out passwordHash, out passwordsalt);
        }

        public async Task<List<AppUser>> GetAll()
        {
           return await repo.GetAll();
        }

        public async Task<AppUser> GetByUsername(string data)
        {
          return await repo.GetByUsername(data);
        }

        public async Task<bool> VerifyPassowrd(string password, string username, byte[] passwordHash, byte[] passwordSalt)
        {
          return await repo.VerifyPassowrd(password, username, passwordHash, passwordSalt);
        }
    }
}
