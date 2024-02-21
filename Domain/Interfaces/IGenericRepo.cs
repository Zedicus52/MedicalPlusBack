namespace Domain.Interfaces;

public interface IGenericRepo<T,K> where T : class
{
    Task<List<T>> GetAll();
    ValueTask<T?> GetById(K id);
    void Add(T item);
    void Delete(K id);
    void Update(T item);
}