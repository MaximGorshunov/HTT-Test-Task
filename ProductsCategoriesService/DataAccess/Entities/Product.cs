using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Amount { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
