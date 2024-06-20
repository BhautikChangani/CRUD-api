using System;
using System.Collections.Generic;

namespace crud_api.Models;

public partial class Products1
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public short? SupplierId { get; set; }

    public short? CategoryId { get; set; }

    public string? QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? UnitesInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }
}
