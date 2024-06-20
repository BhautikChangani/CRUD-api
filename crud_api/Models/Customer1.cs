using System;
using System.Collections.Generic;

namespace crud_api.Models;

public partial class Customer1
{
    public int CustomerId { get; set; }

    public string CustName { get; set; } = null!;

    public string? City { get; set; }

    public int? Grade { get; set; }

    public int? SalesmanId { get; set; }

    public virtual ICollection<Orders1> Orders1s { get; set; } = new List<Orders1>();

    public virtual Salesman1? Salesman { get; set; }
}
