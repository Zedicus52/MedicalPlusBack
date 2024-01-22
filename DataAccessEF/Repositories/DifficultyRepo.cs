using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccessEF.Repositories;

public class DifficultyRepo : GenericRepo<Difficulty>, IDifficultyRepo
{
    public DifficultyRepo(MedicalPlusDbContext dbContext) : base(dbContext)
    {
    }
}