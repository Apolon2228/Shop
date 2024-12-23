using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();
}
