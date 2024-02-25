using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccessEF.Repositories;

public class ProblemRepo : GenericRepo<Problem, int>, IProblemRepo
{
    public ProblemRepo(MedicalPlusDbContext dbContext) : base(dbContext)
    {
    }
}