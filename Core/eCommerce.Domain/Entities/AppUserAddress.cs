using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class AppUserAddress : BaseEntity
    {
        public string Address { get; set; }
        public string? City { get; set; }
        public ICollection<AppUserInfo> userInfo { get; set; }
    }
}
