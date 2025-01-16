using System;
using System.Collections.Generic;

namespace EKART.Models;

public partial class Region
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; } = null!;

    public string? Status { get; set; }

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
