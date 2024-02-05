using System;
using System.Collections.Generic;


namespace Domain.Models;

public partial class Fio
{

    public int IdFio { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
    public Fio(string name, string surname, string patronymic)
    {
    
        this.Name = name;
        this.Surname = surname;
        this.Patronymic = patronymic;
    }
}
