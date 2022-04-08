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
    public class CartServices : ICartServices
    {
        private ICartRepository<Cart> repo;
        public CartServices(ICartRepository<Cart> _repo)
        {
            repo = _repo;
        }
        public async void AddtoCart(Guid userID, Guid productID, int quantity)
        {
            repo.AddtoCart(userID,productID,quantity);
        }

        public void ClearCart(Guid cartID)
        {
            repo.ClearCart(cartID);
        }

        public async void DeleteFromCart(Guid userID, Guid productID)
        {
            repo.DeleteFromCart(userID,productID);
        }

        public async Task<List<Cart>> GetAll()
        {
           return await repo.GetAll();
        }

        public async Task<Cart> GetById(Guid id)
        {
           return await repo.GetById(id);
        }
    }
}
