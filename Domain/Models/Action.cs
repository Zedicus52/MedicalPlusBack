using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Action
{
    public int IdAction { get; set; }

    public string Action1 { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
