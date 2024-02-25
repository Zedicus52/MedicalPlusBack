using Domain.Models.WebModels;
using System;
using System.Collections.Generic;


namespace Domain.Models;

public partial class Patient
{
    public int IdPatient { get; set; }

    public int? IdGender { get; set; }

    public int? IdFio { get; set; }

    public int PhoneNumber { get; set; }
    public int MedicalCardNumber { get; set; }

    public DateTime BirthDate { get; set; }

    public DateTime ApplicationDate { get; set; }

    public Fio? IdFioNavigation { get; set; }

    public Gender? IdGenderNavigation { get; set; }

   // public Problem? IdProblemNavigation { get; set; }
    public virtual ICollection<Problem> Problems { get; set; } = new List<Problem>();

    public Patient()
    {
        
    }

    public Patient(int phoneNumber, int medicalCardNumber, DateTime birthday, DateTime applicationDate,Fio fio,Gender? gender)
    {
        this.PhoneNumber = phoneNumber;
        this.BirthDate = birthday;
        this.ApplicationDate= applicationDate;
        this.IdFio = fio.IdFio; 
        MedicalCardNumber = medicalCardNumber;
        this.IdGender = gender.IdGender;
        this.IdGenderNavigation = gender;
        this.IdFioNavigation = fio;
    }
}
