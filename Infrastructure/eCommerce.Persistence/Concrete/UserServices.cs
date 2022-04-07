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

        public Task<List<AppUser>> GetAll()
        {
           return repo.GetAll();
        }

        public Task<AppUser> GetByUsername(string data)
        {
          return repo.GetByUsername(data);
        }

        public Task<bool> VerifyPassowrd(string password, string username, byte[] passwordHash, byte[] passwordSalt)
        {
          return repo.VerifyPassowrd(password, username, passwordHash, passwordSalt);
        }
    }
}
