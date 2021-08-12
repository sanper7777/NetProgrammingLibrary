using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleMVC.DTO;

namespace SimpleMVC.Controllers
{
    [Route("[controller]")]
    public class ParameterController : Controller
    {
        [Route("GetSomeData")]
        public IActionResult GetSomeDataFromQuery([FromQuery] string value)
        {
            return Ok($"The Value:{value} is from Query string");
        }

        [Route("Get/{value}")]
        [HttpGet]
        public IActionResult Get([FromRoute] string value)
        {
            return Ok($"The Value:{value} is from Route");
        }

        [Route("Post")]
        [HttpPost]
        public IActionResult Post([FromHeader] string value)
        {
            return Ok($"The Value:{value} is from Header");
        }

        [Route("PostBody")]
        [HttpPost]
        public IActionResult PostBody([FromBody] Example value)
        {
            return Ok($"The Value:{value} is from Body");
        }

        [Route("PostForm")]
        [HttpPost]
        public IActionResult PostFrom([FromForm] string fileName,[FromForm] IFormFile file)
        {
            return Ok($"The Value:{fileName} is from Body");
        }
    }
}