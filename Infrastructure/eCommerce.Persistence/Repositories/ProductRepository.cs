using eCommerce.Application.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Repositories
{
    public class ProductRepository<T> : IProductRepository<T> where T : class, new()
    {
        private readonly eCommerceDbContext eCommerceDbContext;
        public ProductRepository(eCommerceDbContext _eCommerceDbContext)
        {
            eCommerceDbContext = _eCommerceDbContext;
        }
        public async Task<List<Product>> GetAll()
        {
            return await this.eCommerceDbContext.Set<Product>().AsNoTracking().Include(x=>x.category).Include(x=>x.SellerList).ToListAsync();
        }
        public async Task<Product> GetById(Guid id)
        {
            return await this.eCommerceDbContext.Set<Product>().Include(x=>x.category).Include(x=>x.SellerList).FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
