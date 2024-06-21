using System;
using System.Collections.Generic;

namespace crud_api.Models;

public partial class Employee1
{
    public int EmpId { get; set; }

    public int? DeptId { get; set; }

    public int? MngrId { get; set; }

    public string? EmpName { get; set; }

    public decimal? Salary { get; set; }

    public virtual Department1? Dept { get; set; }

    public virtual Manager1? Mngr { get; set; }
}
