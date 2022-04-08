using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class AppUserInfo : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid userID { get; set; }
        public AppUser User { get; set; }
        public Guid userAddressID { get; set; }
        public AppUserAddress UserAddress { get; set; }
       
    }
}
