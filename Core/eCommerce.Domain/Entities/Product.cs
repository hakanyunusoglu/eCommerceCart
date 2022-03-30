using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public List<SellerList> SellerList { get; set; }
        public Category category { get; set; }
        public Guid categoryID { get; set; }
    }
}
