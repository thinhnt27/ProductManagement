﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.ProductManagement.Service.BusinessModel
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public int CategoryId { get; set; }
    }
}
