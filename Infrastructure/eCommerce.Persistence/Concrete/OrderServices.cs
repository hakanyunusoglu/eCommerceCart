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
    public class OrderServices : IOrderServices
    {
        private IOrderRepository<Order> repo;
        public OrderServices(IOrderRepository<Order> _repo)
        {
            repo = _repo;
        }

        public  void addOrder(Order model)
        {
           repo.addOrder(model);
        }

        public async Task<List<Order>> GetOrders(Guid userID)
        {
            return await repo.GetOrders(userID);
        }
    }
}
