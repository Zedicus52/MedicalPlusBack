using System;
using System.Collections.Generic;


namespace Domain.Models;

public partial class Log
{
    public int IdLog { get; set; }

    public string IdUser { get; set; }

    public int? IdAction { get; set; }

    public string ObjectName { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? ChangeDate { get; set; }

    public virtual LogAction? IdActionNavigation { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public Log()
    {
        
    }
    public Log(string objectName, string message, DateTime creationDate, DateTime changeDate, LogAction action, User user)
    {
        this.ObjectName = objectName;
        this.Message = message;
        this.CreationDate = changeDate;
        this.ChangeDate = creationDate;
        this.IdUser = user.Id;
        this.IdUserNavigation = user;
        this.IdActionNavigation = action;
        this.IdAction = action.IdAction;

    }
}
