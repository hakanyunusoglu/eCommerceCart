﻿using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Title { get; set; }
        public string Description { get; set; }
        public List<Product> ProductList { get; set; }

    }
}
