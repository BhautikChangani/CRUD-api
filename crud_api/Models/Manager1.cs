using System;
using System.Collections.Generic;

namespace crud_api.Models;

public partial class Manager1
{
    public int MngrId { get; set; }

    public string MngrName { get; set; } = null!;

    public virtual ICollection<Employee1> Employee1s { get; set; } = new List<Employee1>();
}
