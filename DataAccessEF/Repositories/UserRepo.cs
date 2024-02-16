using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessEF.Repositories;

public class UserRepo : GenericRepo<User,string>, IUserRepo
{
    public UserRepo(MedicalPlusDbContext dbContext) : base(dbContext)
    {
    }

    public Task<User?> GetByName(string name)
    {
        return this._dbContext.Set<User>().FirstOrDefaultAsync(x => x.UserName== name);
    }
}