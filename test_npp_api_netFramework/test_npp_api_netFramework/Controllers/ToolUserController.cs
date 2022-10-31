using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using test_sql.Services.User;
using test_sql.Services.Tool;
using test_sql.Services.Tool_User;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using test_sql.EF_entities;

namespace test_sql.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ToolUserController : ApiController
    {
        private readonly IToolUserService _tool_userService = new ToolUserService();

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
        [NonAction]
        protected override void Dispose(bool disposing)
        {
            _tool_userService.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult<IEnumerable<EF_entities.Tool_User>> Get()
        {
            var responce =  _tool_userService.GetAll();

            var json = Json(responce, JsonSettings());

            return json;
        }


        [HttpPut]
        public async Task<bool> Put([FromBody] Tool_User tooluserModel)
        {
            var responce = await _tool_userService.addToolUserAsync(tooluserModel);

            return responce;
        }

        [HttpDelete]
        public async Task<bool> Delete([FromBody] Tool_User tooluserModel)
        {
            var responce = await _tool_userService.removeToolUserAsync(tooluserModel);

            return responce;
        }
    }
}
