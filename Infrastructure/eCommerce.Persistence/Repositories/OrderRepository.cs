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
    public class OrderRepository<T> : IOrderRepository<T> where T : class, new()
    {
        private readonly eCommerceDbContext eCommerceDbContext;
        public OrderRepository(eCommerceDbContext _eCommerceDbContext)
        {
            eCommerceDbContext = _eCommerceDbContext;
        }
        public void addOrder(Order model)
        {           
            this.eCommerceDbContext.Set<Order>().Add(model);
            this.eCommerceDbContext.SaveChanges();
        }

        public async Task<List<Order>> GetOrders(Guid userID)
        {
            var orders =  this.eCommerceDbContext.Set<Order>().Include(x => x.OrderItems).ThenInclude(x=>x.Product).ThenInclude(x=>x.SellerList).AsQueryable();
            if(!string.IsNullOrEmpty(userID.ToString()))
            {
                orders = orders.Where(x=>x.userID == userID).OrderByDescending(x=>x.CreatedDate);
            }
            return orders.ToList();
        }
    }
}
