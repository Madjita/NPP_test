using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using test_sql.Data;
using test_sql.EF_entities;

namespace test_sql.Services.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            Debug.WriteLine($"Create context {typeof(T).Name}");
            _context = context;
        }

        public Repository()
        {
            Debug.WriteLine($"Create context {typeof(T).Name}");
            _context = new Context();
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public async Task<IEnumerable<T>> toListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public Context GetContext()
        {
            return _context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                //todo: need to add logger
                throw new Exception("Error: Repository \"GetByIdAsync\"");
            }

            return result;
        }

        public async Task<long> AddAsync(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return result.Id;
        }

        public async Task<long> RemoveAsync(T entity)
        {
            var result = _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return result.Id;
        }

        public async Task<long> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}