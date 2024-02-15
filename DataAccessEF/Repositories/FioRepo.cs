using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccessEF.Repositories;

public class FioRepo : GenericRepo<Fio, int>, IFioRepo
{
    public FioRepo(MedicalPlusDbContext dbContext) : base(dbContext)
    {
    }
}