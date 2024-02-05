namespace Domain.Interfaces;

public interface IGenericRepo<T> where T : class
{
    Task<List<T>> GetAll();
    ValueTask<T?> GetById(string id);
    void Add(T item);
    void Delete(string id);
    void Update(T item);
}