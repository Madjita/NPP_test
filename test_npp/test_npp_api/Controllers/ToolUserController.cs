using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test_npp_api.EF_entities;
using test_npp_api.Models;
using test_npp_api.Services.Tool_User;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test_npp_api.Controllers
{
    public class ToolUserController : Controller
    {

        private readonly IToolUserService  _tool_userService;

        public ToolUserController(IToolUserService tool_userService)
        {
            _tool_userService = tool_userService;
        }

        [Route("/api/[controller]")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var responce = await _tool_userService.GetAllAsync();

            return Ok(responce);
        }

        [Route("/api/[controller]")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Tool_User tooluserModel)
        {
            var responce = await _tool_userService.addToolUserAsync(tooluserModel);

            if (!responce)
            {
                return BadRequest(new { message = "Table Check is empty !" });
            }

            return Ok(responce);
        }

        [Route("/api/[controller]")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Tool_User tooluserModel)
        {
           var responce = await _tool_userService.removeToolUserAsync(tooluserModel);

           if (!responce)
           {
                return BadRequest(new { message = "Delete error!" });
           }

           return Ok();
        }
    }
}

