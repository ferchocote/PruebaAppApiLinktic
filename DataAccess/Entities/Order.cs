using System;
using System.Collections.Generic;

namespace PruebaAppApi.DataAccess.Entities;

public partial class Order
{
    public Guid ID { get; set; }

    public DateTime OrderDate { get; set; }

    public long Number { get; set; }

    public Guid User { get; set; }

    public virtual ICollection<OrderItem> OrderItem { get; set; } = new List<OrderItem>();

    public virtual User UserNavigation { get; set; } = null!;
}
