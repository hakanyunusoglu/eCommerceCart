using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Abstract
{
    public interface ICartServices
    {
        Task<List<Cart>> GetAll();
        Task<Cart> GetById(Guid id);
        void AddtoCart(Guid userID, Guid productID, int quantity);
        void DeleteFromCart(Guid userID, Guid productID);
        void ClearCart(Guid cartID);
    }
}
