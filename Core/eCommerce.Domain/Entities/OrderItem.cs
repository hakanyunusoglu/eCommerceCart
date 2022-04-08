using eCommerce.Domain.Entities.Common;

namespace eCommerce.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid orderID { get; set; }
        public Order Order { get; set; }
        public Guid productID { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}