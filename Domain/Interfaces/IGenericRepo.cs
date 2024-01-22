namespace Domain.Interfaces;

public interface IGenericRepo<T> where T : class
{
    Task<List<T>> GetAll();
    ValueTask<T?> GetById(int id);
    void Add(T item);
    void Delete(int id);
    void Update(T item);
}