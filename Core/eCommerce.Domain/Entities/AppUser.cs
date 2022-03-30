using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public AppUserInfo userInfo { get; set; }
    }
}
