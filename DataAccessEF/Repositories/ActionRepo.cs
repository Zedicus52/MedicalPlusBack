using DataAccessEF.Data;
using Domain.Interfaces;
using LogAction = Domain.Models.LogAction;

namespace DataAccessEF.Repositories;

public class ActionRepo : GenericRepo<LogAction, int>, IActionRepo
{
    public ActionRepo(MedicalPlusDbContext dbContext) : base(dbContext)
    {
    }
}