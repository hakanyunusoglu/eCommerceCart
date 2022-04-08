using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Repositories
{
    public interface IOrderRepository<T> where T : class, new()
    {
        void addOrder(Order model);
        Task<List<Order>> GetOrders(Guid userID);
    }
}
