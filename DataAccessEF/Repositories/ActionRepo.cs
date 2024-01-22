using DataAccessEF.Data;
using Domain.Interfaces;
using Action = Domain.Models.Action;

namespace DataAccessEF.Repositories;

public class ActionRepo : GenericRepo<Action>, IActionRepo
{
    public ActionRepo(MedicalPlusDbContext dbContext) : base(dbContext)
    {
    }
}