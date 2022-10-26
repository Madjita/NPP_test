using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test_npp_api.Models;
using test_npp_api.Services.Tool;
using test_npp_api.Services.User;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test_npp_api.Controllers
{
    public class ToolController : Controller
    {
        private readonly IToolService _toolService;
        private readonly IToolService _tool_userService;

        public ToolController(IToolService toolService, IToolService tool_userService)
        {
            _toolService = toolService;
            _tool_userService = tool_userService;
        }

        // GET: /<controller>/User
        [Route("/api/tools")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var responce = await _toolService.GetAll_notEmptyAsync();

            foreach(var item in responce)
            {
                await _toolService.LoadAsync(item);
            }

            responce.OrderBy(x => x.Count > x.tool_users.Count);

            return Ok(responce);
        }

       
    }
}

