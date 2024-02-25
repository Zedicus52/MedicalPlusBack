using System;
using System.Collections.Generic;


namespace Domain.Models;

public partial class Gender
{
    public int IdGender { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public Gender()
    {
        
    }

    public Gender(string name)
    {
        this.Name = name;
    }
}
