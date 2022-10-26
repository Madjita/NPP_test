using System;
using System.Security.Principal;
using test_npp_api.EF_entities;
using test_npp_api.Models;

namespace test_npp_api.Services.Tool
{
    public interface IToolService :
        IToolServiceRepository
    {

    }

    public interface IToolServiceRepository
    {
        Task<IEnumerable<EF_entities.Tool>> GetAll_notEmptyAsync();
        Task LoadAsync(EF_entities.Tool tool);

        Task<EF_entities.Tool> GetByIdAsync(int id);

    }
}

