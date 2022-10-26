using System;
using test_npp_api.EF_entities;

namespace test_npp_api.Services.User
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

