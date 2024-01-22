using System;
using System.Collections.Generic;


namespace Domain.Models;

public partial class User
{
    public int IdUser { get; set; }

    public int? IdRole { get; set; }

    public int? IdFio { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Fio? IdFioNavigation { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual ICollection<Problem> Problems { get; set; } = new List<Problem>();
}
