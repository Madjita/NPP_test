using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test_sql.Services.Tool_User
{
    public interface IToolUserService :
         IDisposable,
         IToolUserServiceRepository
    {

    }

    public interface IToolUserServiceRepository
    {
        IEnumerable<EF_entities.Tool_User> GetAll();
        Task<EF_entities.Tool_User> GetByIdAsync(int id);

        Task<bool> addToolUserAsync(EF_entities.Tool_User newTool);

        Task<bool> removeToolUserAsync(EF_entities.Tool_User newTool);
    }

}

