﻿using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class ProductSupplier
{
    public int ProductSupplierId { get; set; }

    public int? ProductId { get; set; }

    public int? SupplierId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
