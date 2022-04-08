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
    public class CartRepository<T> : ICartRepository<T> where T : class, new()
    {
        private readonly eCommerceDbContext eCommerceDbContext;
        public CartRepository(eCommerceDbContext _eCommerceDbContext)
        {
            eCommerceDbContext = _eCommerceDbContext;
        }
        public async void AddtoCart(Guid userID, Guid productID, int quantity)
        {
            if (userID != null && productID != null)
            {
                //Kullanıcıya ait oluşturulmuş cart var mı diye kontrol ediliyor
                var checkCart = GetById(userID);
                var cart = checkCart.Result;

                //cart varsa ekleme yada güncelleme işlemi yapılacak
                if (cart != null)
                {
                    //Cart ın içerisinde eklenmek istenen ürün var mı diye kontrol ediliyor. Varsa index numarası alınacak
                    var index = cart.CartItemList.FindIndex(x => x.productID == productID);
                    //Eğer ürün cart ın içerisinde yoksa yeni bir ürün olarak carta ekleme işlemi yapıyoruz
                    if (index < 0)
                    {
                        cart.CartItemList.Add(new CartItem()
                        {
                            productID = productID,
                            cartID = cart.ID,
                            Quantity = quantity,
                            CreatedDate = DateTime.Now
                        });
                        this.eCommerceDbContext.SaveChanges();
                    }
                    //Eğer ürün cart ın içerisinde varsa yukarıda index numarasını aldığımız ürünün index inden quantity alanını güncelliyoruz
                    else
                    {
                        cart.CartItemList[index].Quantity += quantity;
                    }
                    UpdatetoCart(cart);
                }
                this.eCommerceDbContext.SaveChanges();
            }
        }

        public async void ClearCart(Guid cartID)
        {
            var checkCardItems =  this.eCommerceDbContext.Set<CartItem>().Where(x => x.cartID == cartID).ToListAsync();
            var cardItems = checkCardItems.Result;
            this.eCommerceDbContext.Set<CartItem>().RemoveRange(cardItems);
            this.eCommerceDbContext.SaveChanges();
        }

        public async void DeleteFromCart(Guid userID, Guid productID)
        {
            var checkCart = GetById(userID);
            if (checkCart != null)
            {
                var cart = checkCart.Result;
                var checkCartItem =  this.eCommerceDbContext.Set<CartItem>().FirstOrDefaultAsync(x => x.Product.ID == productID && x.cartID == cart.ID);
                var cartItem = checkCartItem.Result;
                this.eCommerceDbContext.Set<CartItem>().Remove(cartItem);
                eCommerceDbContext.SaveChanges();
            }           
        }
        public async Task<List<Cart>> GetAll()
        {
            return await this.eCommerceDbContext.Set<Cart>().AsNoTracking().Include(x => x.CartItemList).ThenInclude(x => x.Product).ToListAsync();
        }
        public async Task<Cart> GetById(Guid id)
        {
            return await this.eCommerceDbContext.Set<Cart>().Include(x => x.CartItemList).ThenInclude(x => x.Product.SellerList).Include(x => x.CartItemList).ThenInclude(x => x.Product).ThenInclude(x => x.category).FirstOrDefaultAsync(x => x.userID == id);
        }
        public async void UpdatetoCart(Cart cart)
        {
            this.eCommerceDbContext.Set<Cart>().Update(cart);
            this.eCommerceDbContext.SaveChanges();
        }
    }
}
