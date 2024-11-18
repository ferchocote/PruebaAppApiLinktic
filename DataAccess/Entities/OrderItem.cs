using System;
using System.Collections.Generic;

namespace PruebaAppApi.DataAccess.Entities;

public partial class OrderItem
{
    public Guid ID { get; set; }

    public Guid Order { get; set; }

    public Guid Product { get; set; }

    public int Quantity { get; set; }

    public virtual Order OrderNavigation { get; set; } = null!;

    public virtual Product ProductNavigation { get; set; } = null!;
}
