using System;
using System.Collections.Generic;


namespace Domain.Models;

public partial class Patient
{
    public int IdPatient { get; set; }

    public int? IdProblem { get; set; }

    public int? IdGender { get; set; }

    public int? IdFio { get; set; }

    public int PhoneNumber { get; set; }

    public DateTime BirthDate { get; set; }

    public DateTime ApplicationDate { get; set; }

    public virtual Fio? IdFioNavigation { get; set; }

    public virtual Gender? IdGenderNavigation { get; set; }

    public virtual Problem? IdProblemNavigation { get; set; }
}
