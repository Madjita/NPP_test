using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using test_sql.Services.Tool;
//using ToolService = test_sql.Services.Tool.ToolService;
//using IToolService = test_sql.Services.Tool.IToolService;
using test_sql.Services.Tool_User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using System.Web.Http.Results;
using NonActionAttribute = System.Web.Http.NonActionAttribute;
using System.Web.Http.Cors;

namespace test_sql.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ToolController : ApiController
    {
        private readonly IToolService _toolService = new ToolService();
        //private readonly IToolUserService _tool_userService = new ToolUserService();

        [NonAction]
        private JsonSerializerSettings JsonSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        // GET: Tool
        [Route("api/tools")]
        //[HttpGet]
        public async Task<JsonResult<IEnumerable<EF_entities.Tool>>> Get()
        {
            var responce = await _toolService.GetAll_notEmptyAsync();

            foreach (var item in responce)
            {
                await _toolService.LoadAsync(item);
            }

            responce.OrderBy(x => x.Count > x.tool_users.Count);

            var json = Json(responce, JsonSettings());

            return json;
        }

    }
}