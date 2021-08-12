using Microsoft.AspNetCore.Mvc;

namespace SimpleMVC.Controllers
{
    [Route("Admin/[controller]")]
    public class ContactController : Controller
    {
        [Route("Main")]
        public IActionResult Index()
        {
            return Ok("Invoke controller : Admin/Contact action: Main");
        }
        [Route("Details")]
        public IActionResult SomeActionName(int id)
        {
            return Ok("Invoke controller : Admin/Contact action: Details");
        }
    }
}