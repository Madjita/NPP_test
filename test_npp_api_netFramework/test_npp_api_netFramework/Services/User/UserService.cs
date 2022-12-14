using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test_sql.Services.Repository;

namespace test_sql.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<EF_entities.User> _userRepository;

        public UserService(IRepository<EF_entities.User> userRepository)
        {
            _userRepository = new Repository<EF_entities.User>();
        }

        public UserService()
        {
            _userRepository = new Repository<EF_entities.User>();
        }

        public void Dispose() => Dispose(true);

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _userRepository.Dispose();
                }
            }
            this.disposed = true;
        }

        public async Task<IEnumerable<EF_entities.User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        Task<EF_entities.User> IUserServiceRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}