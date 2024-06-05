namespace Crm.Domain.Shared
{
    public interface IBaseRepositroy<T> where T : BaseEntity
    {
        Task<T?> GetAsync(long id);
        Task<List<T>> GetListAsync();

        Task AddAsync(T entity);
        void Add(T entity);

        void Update(T entity);

        Task Save();

        T? Get(long id);
    }
}
