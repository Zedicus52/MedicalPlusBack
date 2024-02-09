using Domain.Models;

namespace Domain.Interfaces;

public interface IGenderRepo : IGenericRepo<Gender>
{
    ValueTask<Gender?> GetById(int id);
  
}