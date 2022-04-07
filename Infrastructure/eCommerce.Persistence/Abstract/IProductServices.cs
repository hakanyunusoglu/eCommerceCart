using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Abstract
{
    public interface IProductServices
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(Guid id);
    }
}
