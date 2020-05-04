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
    public class EmotionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetEmotions()
        {
            return new string[] { "Emo1", "Emo2" };
        }

        [HttpPost]
        public string CreateEmotion()
        {
            return "CreatedEmotion";
        }

    }
}
