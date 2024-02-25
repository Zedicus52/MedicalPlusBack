using System;
using System.Collections.Generic;


namespace Domain.Models;

public partial class Problem
{
    public int IdProblem { get; set; }

    public string IdUser { get; set; }
    public string IdCreateUser { get; set; }

    public int? IdDifficulty { get; set; }
    public int? IdPatient { get; set; }

    public string Diagnosis { get; set; } = null!;
    public string ResearchNumber { get; set; } = null!;
    public string ClinicalData { get; set; } = null!;
    public string OperationType { get; set; } = null!;

    public string MicroDesc { get; set; } = null!;

    public string MacroDesc { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? ChangeDate { get; set; }
    public DateTime OperationDate { get; set; }

    public virtual Difficulty? IdDifficultyNavigation { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
    public virtual User IdCreateUserNavigation { get; set; } = null!; 
    public virtual Patient IdPatientNavigation { get; set; } = null!;

  //  public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public Problem()
    {
        
    }
    public Problem(string researchNumber,string diagnosis, string clinicalData, string micro, string macro, string operationType, DateTime creation, DateTime operaionDate, DateTime change, User user, Difficulty difficulty,Patient patient)
    {
        this.IdDifficultyNavigation = difficulty;
        this.IdDifficulty = difficulty.IdDifficulty;
        this.MicroDesc = micro;
        this.MacroDesc = macro;
        this.Diagnosis = diagnosis;
        this.IdUser = user.Id;
        IdCreateUser = user.Id;
        this.IdPatient = patient.IdPatient;
        this.IdPatientNavigation = patient;
        this.IdUserNavigation = user;
        IdCreateUserNavigation = user;
        this.CreationDate = creation;
        this.ChangeDate = change;
        OperationDate = operaionDate;
        ClinicalData = clinicalData;
        OperationType=  operationType;
        ResearchNumber = researchNumber;
    }
}
