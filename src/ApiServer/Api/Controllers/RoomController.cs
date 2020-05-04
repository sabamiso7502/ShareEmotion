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
    public class RoomController : ControllerBase
    {
        [HttpPost]
        public string CreateRoom()
        {
            return "FIXED_ROOM_NUMBER";
        }
    }
}
