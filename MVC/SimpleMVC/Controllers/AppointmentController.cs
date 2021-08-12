using System;
using Microsoft.AspNetCore.Mvc;

namespace SimpleMVC.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
            // string todayDate = DateTimeOffset.Now.UtcDateTime.ToShortDateString();
            // return Ok(todayDate);
        }
        public IActionResult Details(int id)
        {
            return Ok($"You have enter id = {id}");
        }
    }
}