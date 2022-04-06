using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        [DisplayName("Ürün Adı")]
        public string? Title { get; set; }
        public string? Name { get; set; }
        [DisplayName("Ürün Açıklama")]
        public string? Description { get; set; }
        [DisplayName("Ürün Resmi")]
        public string? Image { get; set; }
        public List<SellerList> SellerList { get; set; }
        public Category category { get; set; }
        public Guid categoryID { get; set; }
    }
}
