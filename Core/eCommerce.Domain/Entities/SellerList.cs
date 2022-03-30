using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class SellerList : BaseEntity
    {
        public Product product { get; set; }
        public Guid productID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
