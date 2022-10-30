using System.Collections.Generic;
using System.Threading.Tasks;
using test_sql.Data;

namespace test_sql.Services.User
{
    public interface IUserService :
        IUserServiceRepository
    {

    }

    public interface IUserServiceRepository
    {
        Task<IEnumerable<EF_entities.User>> GetAllAsync();
        Task<EF_entities.User> GetByIdAsync(int id);
    }
}
