using eCommerce.Domain.Entities;

namespace eCommerce.UI.Models.DTO
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public List<Product> productList { get; set; }
    }
}
