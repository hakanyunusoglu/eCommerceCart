using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public AppUser User { get; set; }
        public Guid userID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }
        public string? Email { get; set; }
        public EnumOrderState orderState { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }

    public enum EnumOrderState
    {
        waiting = 0,
        unpaid = 1,
        completed = 2
    }
}
