using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_sql.EF_entities;
using test_sql.Data;

namespace test_sql.Services.Repository
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
