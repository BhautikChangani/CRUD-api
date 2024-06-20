using System;
using System.Collections.Generic;

namespace crud_api.Models;

public partial class Orders1
{
    public int OrdNo { get; set; }

    public decimal? PurchAmt { get; set; }

    public DateTime? OrdDate { get; set; }

    public int? CustomerId { get; set; }

    public int? SalesmanId { get; set; }

    public virtual Customer1? Customer { get; set; }

    public virtual Salesman1? Salesman { get; set; }
}
