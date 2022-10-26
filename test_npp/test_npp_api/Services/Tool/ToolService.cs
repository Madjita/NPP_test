using System;
using System.Data;
using System.Security.Principal;
using test_npp_api.Services.Repository;
using test_npp_api.EF_entities;
using test_npp_api.Models;
using Microsoft.EntityFrameworkCore;

namespace test_npp_api.Services.Tool
{
    public class ToolService : IToolService
    {
        private readonly IRepository<EF_entities.Tool> _toolRepository;
        private readonly IRepository<EF_entities.User> _userRepository;

        public ToolService(
         IRepository<test_npp_api.EF_entities.Tool> toolRepository,
         IRepository<test_npp_api.EF_entities.User> userRepository
        )
        {
            _toolRepository = toolRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<EF_entities.Tool>> GetAll_notEmptyAsync()
        {
            var res = await _toolRepository.Get()
                .Where(x => x.Count > 0)
                .ToListAsync();

            return res;
        }

        public Task<EF_entities.Tool> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task LoadAsync(EF_entities.Tool tool)
        {
            await _toolRepository.GetContext().Entry(tool).Collection(x => x.tool_users).LoadAsync();

            foreach(var item in tool.tool_users)
            {
                await _toolRepository.GetContext().Entry(item).Reference(x => x.Tool).LoadAsync();
            }

            
        }
    }
}

