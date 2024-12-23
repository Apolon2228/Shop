using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Compatibility
{
    public int CompatibilityId { get; set; }

    public int? ProductId1 { get; set; }

    public int? ProductId2 { get; set; }

    public int? IsCompatible { get; set; }

    public virtual Product? ProductId1Navigation { get; set; }

    public virtual Product? ProductId2Navigation { get; set; }
}
