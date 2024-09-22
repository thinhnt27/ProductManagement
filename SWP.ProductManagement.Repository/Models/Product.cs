using System;
using System.Collections.Generic;

namespace SWP.ProductManagement.Repository.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int UnitsInStock { get; set; }

    public decimal UnitPrice { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
