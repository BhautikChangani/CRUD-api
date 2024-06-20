using System;
using System.Collections.Generic;

namespace crud_api.Models;

public partial class Salesman1
{
    public int SalesmanId { get; set; }

    public string Name { get; set; } = null!;

    public string? City { get; set; }

    public decimal? Commision { get; set; }

    public virtual ICollection<Customer1> Customer1s { get; set; } = new List<Customer1>();

    public virtual ICollection<Orders1> Orders1s { get; set; } = new List<Orders1>();
}
