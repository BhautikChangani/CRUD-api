using System;
using System.Collections.Generic;

namespace crud_api.Models;

public partial class Column
{
    public int ColumnId { get; set; }

    public int? PageId { get; set; }

    public string? ColumnName { get; set; }
}
