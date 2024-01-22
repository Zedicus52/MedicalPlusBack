using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccessEF.Repositories;

public class RoleRepo : GenericRepo<Role>, IRoleRepo
{
    public RoleRepo(MedicalPlusDbContext dbContext) : base(dbContext)
    {
    }
}