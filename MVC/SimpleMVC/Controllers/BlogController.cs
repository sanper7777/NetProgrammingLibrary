using Microsoft.AspNetCore.Mvc;

namespace SimpleMVC.Controllers
{
    public class BlogController : Controller
    {
        [Route("Blog")]
        [Route("Blog/Index")]
        public IActionResult Index()
        {
            return Ok("Invoke Blog Controller");
        }
        [Route("Blog/Article")]
        public IActionResult Article()
        {
            return Ok("Invoke Controller Blog Action Article");
        }

        
    } 
}