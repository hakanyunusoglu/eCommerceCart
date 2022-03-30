using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class CartItem:BaseEntity
    {
        public Product Product { get; set; }
        public Guid productID { get; set; }
        public Cart Cart { get; set; }
        public Guid cartID { get; set; }
        public int Quantity { get; set; }
    }
}
