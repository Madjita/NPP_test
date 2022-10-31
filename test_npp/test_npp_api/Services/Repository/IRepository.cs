using System;
using test_npp_api.Data;
using test_npp_api.EF_entities;

namespace test_npp_api.Services.Repository
{
    public interface IRepository<T> : IDisposable,IRepositorySync<T>, IRepositoryAsync<T> where T : BaseEntity
    {
        Context GetContext();
    }

    public interface IRepositorySync<T> where T : BaseEntity
    {
        IQueryable<T> Get();
        List<T> GetAll();
    }

    public interface IRepositoryAsync<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<long> AddAsync(T entity);
        Task<long> RemoveAsync(T entity);
        Task<long> UpdateAsync(T entity);
        Task<long> SaveAsync();
        Task<IEnumerable<T>> toListAsync();
    }
}

