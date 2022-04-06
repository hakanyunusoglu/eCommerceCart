using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Repositories
{
    public interface IProductRepository<T> where T : class, new()
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(Guid id);
    }
}
