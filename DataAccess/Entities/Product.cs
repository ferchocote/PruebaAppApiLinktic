using System;
using System.Collections.Generic;

namespace PruebaAppApi.DataAccess.Entities;

public partial class Product
{
    public Guid ID { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public bool State { get; set; }

    public virtual ICollection<OrderItem> OrderItem { get; } = new List<OrderItem>();
}
