using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public Guid userID { get; set; }
        public List<CartItem> CartItemList { get; set; }
    }
}
