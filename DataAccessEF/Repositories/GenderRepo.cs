using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccessEF.Repositories;

public class GenderRepo : GenericRepo<Gender>, IGenderRepo
{
    public GenderRepo(MedicalPlusDbContext dbContext) : base(dbContext)
    {
    }
}