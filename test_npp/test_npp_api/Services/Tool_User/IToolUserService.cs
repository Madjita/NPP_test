using System;
using test_npp_api.Models;
using test_npp_api.Services.Tool;

namespace test_npp_api.Services.Tool_User
{
    public interface IToolUserService :
         IToolUserServiceRepository
    {

    }

    public interface IToolUserServiceRepository
    {
        Task<IEnumerable<EF_entities.Tool_User>> GetAllAsync();
        Task<EF_entities.Tool_User> GetByIdAsync(int id);

        Task<bool> addToolUserAsync(EF_entities.Tool_User newTool);

        Task<bool> removeToolUserAsync(EF_entities.Tool_User newTool);
    }

}

