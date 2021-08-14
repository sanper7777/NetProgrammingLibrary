using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace SimpleMVC.Controllers
{
    [Route("[controller]")]
    public class ReturnValueController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReturnValueController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

         #region :: Status Code Result ::
         // Return status code 200 OK
         [Route("OkResult")]
         public IActionResult OkResult()
         {
             return Ok();
         }
       
        // Return status code 201
        // Header filed localtion=http://example.org/myitem
        // Body response  {"name" = "newItem"}
         [Route("CreateResult")]
         public IActionResult CreateResult()
         {
             return Created("http://example.org/myitem",new {name = "newItem"});
         }

         //Return status code 204
         [Route("NoContetResult")]
         public IActionResult NoContetResult()
         {
             return NoContent();
         }

         //Return status code 400
         [Route("BadRequestResult")]
         public IActionResult BadRequestResult()
         {
             return BadRequest();
         }

         //Return status code 401
         [Route("UnauthorizedResult")]
         public IActionResult UnauthorizedResult()
         {
             return Unauthorized();
         }

         //Return status code 404
         [Route("NotFoundResult")]
         public IActionResult NotFoundResult()
         {
             return NotFound();
         }

         //Return status code 415
         [Route("UnsupportedMediaTypeResult")]
         public IActionResult UnsupportedMediaTypeResult()
         {
             return new UnsupportedMediaTypeResult();
         }
         #endregion

         #region :: Status Code with Object Results ::
         [Route("OkObjectResult")]
         public IActionResult OkObjectResult()
         {
            return new OkObjectResult(new {
                message = "200 OK",
                currentDate = DateTimeOffset.UtcNow
            });
         }

         [Route("CreateObjectResult")]
         public IActionResult CreateObjectResult()
         {
             return new CreatedAtActionResult(
                 "CreateObjectResult",
                 "ReturnValue",
                 "",
                 new {
                     message = "201 Created",
                     currentDate = DateTimeOffset.UtcNow
                 });
         }

         [Route("BadRequestObjectResult")]
         public IActionResult BadRequestObjectResult()
         {
             return new BadRequestObjectResult(
                 new{
                     message = "400 Bad Request",
                     currentDate = DateTimeOffset.UtcNow
                 }
             );
         }

         [Route("NotFoundObjectResult")]
         public IActionResult NotFoundObjectResult()
         {
             return new BadRequestObjectResult(
                 new{
                     message = "404 Not Found",
                     currentDate = DateTimeOffset.UtcNow
                 }
             );
         }
         #endregion

         #region :: Redirect Result ::
         [Route("RedirectResult")]
         public IActionResult RedirectResult()
         {
             return Redirect("https://google.com");
         }

         [Route("LocalRedirectResult")]
         public IActionResult LocalRedirectResult()
         {
             return LocalRedirect("/Home/Index");
         }

        
        [Route("RedirectToActionResult")]
         public IActionResult RedirectToActionResult()
         {
             return RedirectToAction("Index","Home");
         }

         #endregion

        #region :: File Result ::
        
        [Route("FileResult")]
        public IActionResult FileResult()
        {
            return File("~/wwwroot/css/site.css","application/text");
        }

        [Route("FileContentResult")]
        public IActionResult FileContentResult()
        {
            var fileContent = System.IO.File.ReadAllBytes("wwwroot/css/site.css");
            return new FileContentResult(fileContent,"text/html; charset=UTF-8");
        }

        [Route("VirtualFileResult")]
        public IActionResult VirtualFileResult()
        {
            return new VirtualFileResult("css/site.css","application/text");
        }

        [Route("PhysicalFileResult")]
        public IActionResult PhysicalFileResult()
        {
            return new PhysicalFileResult(Path.Combine(_webHostEnvironment.ContentRootPath,@"wwwroot\css\site.css"),"application/text");
        }

        #endregion

        #region :: Content Results ::

        //Return View
        public IActionResult Index()
        {
            return View();
        } 

        [Route("PartialViewResult")]
        public IActionResult PartialViewResult()
        {
            return PartialView();
        }
        [Route("JsonResult")]
        public IActionResult JsonResult()
        {
            return Json(new 
            {
                message = "This is a Json result",
                date = DateTimeOffset.UtcNow
            });
        } 
        [Route("ContentResult")]
        public IActionResult ContentResult()
        {
            return Content("Content Result");
        }
        #endregion
    }
}