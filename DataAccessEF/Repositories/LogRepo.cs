using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccessEF.Repositories;

public class LogRepo : GenericRepo<Log, int>, ILogRepo
{
    public LogRepo(MedicalPlusDbContext dbContext) : base(dbContext)
    {
    }
}