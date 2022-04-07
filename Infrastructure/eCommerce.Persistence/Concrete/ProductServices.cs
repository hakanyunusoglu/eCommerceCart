using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Concrete
{
    public class ProductServices : IProductServices
    {
        private IProductRepository<Product> repo;
        public ProductServices(IProductRepository<Product> _repo)
        {
            repo = _repo;
        }
        public Task<List<Product>> GetAll()
        {
           return repo.GetAll();
        }

        public Task<Product> GetById(Guid id)
        {
          return repo.GetById(id);
        }
    }
}
