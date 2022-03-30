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
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public List<AppUserInfo> userInfoList { get; set; }

    }
}
