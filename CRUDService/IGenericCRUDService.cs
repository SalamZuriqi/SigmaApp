using SigmaApplication.Entities;

public interface IGenericCRUDService<T>
        where T : Entity<long>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(long id);
    Task<T> CreateAsync(T dto);
    Task UpdateAsync(long id, T entity);
    Task DeleteAsync(long id);
}