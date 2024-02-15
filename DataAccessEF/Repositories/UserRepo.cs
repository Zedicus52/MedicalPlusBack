using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccessEF.Repositories;

public class UserRepo : GenericRepo<User,string>, IUserRepo
{
    public UserRepo(MedicalPlusDbContext dbContext) : base(dbContext)
    {
    }
}