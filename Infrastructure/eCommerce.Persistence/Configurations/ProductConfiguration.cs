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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(x => x.SellerList).WithOne(x => x.product).HasForeignKey(x => x.productID);
            builder.HasOne(x => x.category).WithMany(x => x.ProductList).HasForeignKey(x => x.categoryID);
        }
    }
}
