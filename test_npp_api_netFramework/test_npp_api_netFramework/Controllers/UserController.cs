using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using test_sql.Services.User;

namespace test_sql.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService = new UserService();

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

        // GET: User
        [Route("api/users")]
        public async Task<JsonResult<IEnumerable<EF_entities.User>>> Get()
        {
            var responce = await _userService.GetAllAsync();

            var json = Json(responce, JsonSettings());

            return json;
        }
    }
}
