using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public int? BrandId { get; set; }

    public string? Description { get; set; }

    public int? InStock { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Compatibility> CompatibilityProductId1Navigations { get; set; } = new List<Compatibility>();

    public virtual ICollection<Compatibility> CompatibilityProductId2Navigations { get; set; } = new List<Compatibility>();

    public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Specification> Specifications { get; set; } = new List<Specification>();
}
