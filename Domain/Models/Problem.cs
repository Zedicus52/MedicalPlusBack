using System;
using System.Collections.Generic;


namespace Domain.Models;

public partial class Problem
{
    public int IdProblem { get; set; }

    public string IdUser { get; set; }

    public int? IdDifficulty { get; set; }

    public string Diagnosis { get; set; } = null!;

    public string MicroDesc { get; set; } = null!;

    public string MacroDesc { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? ChangeDate { get; set; }

    public virtual Difficulty? IdDifficultyNavigation { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
