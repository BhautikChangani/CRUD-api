using System;
using System.Collections.Generic;

namespace crud_api.Models;

public partial class Department1
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public virtual ICollection<Employee1> Employee1s { get; set; } = new List<Employee1>();
}
