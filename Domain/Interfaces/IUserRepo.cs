using Domain.Models;

namespace Domain.Interfaces;

public interface IUserRepo : IGenericRepo<User, string>
{
    Task<User> GetByName(string name);
}