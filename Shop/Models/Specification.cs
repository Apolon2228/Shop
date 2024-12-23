using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Specification
{
    public int SpecificationId { get; set; }

    public int? ProductId { get; set; }

    public string? Keys { get; set; }

    public string? Value { get; set; }

    public virtual Product? Product { get; set; }
}
