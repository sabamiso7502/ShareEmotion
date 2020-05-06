using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        [HttpPost]
        public string CreateGroup()
        {
            // TODO 一意な数字列を生成し返す
            const string FIXED_GROUP_NUMBER = "12345";
            return FIXED_GROUP_NUMBER;
        }
    }
}
