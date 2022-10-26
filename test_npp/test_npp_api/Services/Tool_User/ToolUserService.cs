using System;
using Microsoft.EntityFrameworkCore;
using test_npp_api.EF_entities;
using test_npp_api.Models;
using test_npp_api.Services.Repository;
using test_npp_api.Services.User;

namespace test_npp_api.Services.Tool_User
{
    public class ToolUserService : IToolUserService
    {
        private readonly IRepository<EF_entities.Tool> _toolRepository;
        private readonly IRepository<EF_entities.User> _userRepository;
        private readonly IRepository<EF_entities.Tool_User> _tool_userRepository;

        public ToolUserService(
         IRepository<test_npp_api.EF_entities.Tool> toolRepository,
         IRepository<test_npp_api.EF_entities.User> userRepository,
         IRepository<test_npp_api.EF_entities.Tool_User> tool_userRepository
        )
        {
            _toolRepository = toolRepository;
            _userRepository = userRepository;
            _tool_userRepository = tool_userRepository;
        }

        public async Task<bool> addToolUserAsync(EF_entities.Tool_User newTool)
        {
            try
            {
                var toolBD = await _toolRepository.Get().Where(x => x.Id == newTool.ToolId).FirstOrDefaultAsync();
                var userBD = await _userRepository.Get().Where(x => x.Id == newTool.UserId).FirstOrDefaultAsync();

                if (toolBD == null)
                {
                    throw new Exception("Error toolBD in addToolUserAsync");
                }

                if (userBD == null)
                {
                    throw new Exception("Error userBD in addToolUserAsync");
                }

                if ((toolBD.Count - newTool.GetCount) >= 0)
                {
                    toolBD.Count -= newTool.GetCount;
                }
                else
                {
                    throw new Exception("Error: Tool and User already have been created");
                }

                var newItem = new EF_entities.Tool_User
                {
                    ToolId = toolBD.Id,
                    UserId = userBD.Id,
                    GetCount = newTool.GetCount
                };

                await _tool_userRepository.AddAsync(newItem);

                await _toolRepository.UpdateAsync(toolBD);


                return true;

                /*var chek = await _tool_userRepository.Get().AnyAsync(x => x.ToolId == newTool.toolId && x.UserId == newTool.userId);

                if (!chek)
                {
                


                 
                }
                else
                {
                    throw new Exception("Error: Tool and User already have been created");
                }*/

            }
            catch
            {

            }

            return false;
        }

        public async Task<bool> removeToolUserAsync(EF_entities.Tool_User newTool)
        {
            try
            {
                var context = _tool_userRepository.GetContext();

                var toolUsers = await _tool_userRepository.Get().Where(x => x.Id == newTool.Id).FirstOrDefaultAsync();

                if(toolUsers != null)
                {
                    context.Entry(toolUsers).Reference(x => x.Tool).Load();
                   // context.Entry(toolUsers).Reference(x => x.User).Load();

                    var tool = await _toolRepository.GetByIdAsync(toolUsers.ToolId);

                    if (tool == null)
                    {
                        throw new Exception("Error: Tool GetByIdAsync");
                    }

                    if (newTool.GetCount > 0)
                    {
                        var delta = toolUsers.GetCount - newTool.GetCount;
                        if(delta > 0)
                        {
                         
                            if(tool != null)
                            {
                                tool.Count += delta;
                            }
                        }

                        toolUsers.GetCount = newTool.GetCount;

                        await _tool_userRepository.UpdateAsync(toolUsers);
                    }
                    else
                    {
                        tool.Count += toolUsers.GetCount;
                        await _tool_userRepository.RemoveAsync(toolUsers);
                    }

                   
                    await _toolRepository.UpdateAsync(tool);

                   


                    return true;


                }
              

                

                /*var chek = await _tool_userRepository.Get().AnyAsync(x => x.ToolId == newTool.toolId && x.UserId == newTool.userId);

                if (!chek)
                {
                


                 
                }
                else
                {
                    throw new Exception("Error: Tool and User already have been created");
                }*/

            }
            catch
            {

            }

            return false;
        }

        public async Task<IEnumerable<EF_entities.Tool_User>> GetAllAsync()
        {
            var responce = await _tool_userRepository.Get()
                .Include(x => x.Tool)
                .Include(x => x.User)
                .ToListAsync();

            return responce;
        }

        public Task<EF_entities.Tool_User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}

