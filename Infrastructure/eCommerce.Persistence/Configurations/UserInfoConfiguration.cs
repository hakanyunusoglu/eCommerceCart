using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Configurations
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<AppUserInfo>
    {
        public void Configure(EntityTypeBuilder<AppUserInfo> builder)
        {
            builder.HasOne(x => x.userAddress).WithMany(x => x.userInfoList).HasForeignKey(x => x.userAddressID);
        }
    }
}
