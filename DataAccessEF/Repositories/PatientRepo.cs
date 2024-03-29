using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccessEF.Repositories;

public class PatientRepo : GenericRepo<Patient, int>, IPatientRepo
{
    public PatientRepo(MedicalPlusDbContext dbContext) : base(dbContext)
    {
    }
}