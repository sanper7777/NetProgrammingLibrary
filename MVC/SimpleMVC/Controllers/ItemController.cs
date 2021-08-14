using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleMVC.Data;
using SimpleMVC.Models;

namespace SimpleMVC.Controllers
{
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ItemController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            IEnumerable<Item> items = _dbContext.Items;
            
            return View(items);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item value)
        {
            _dbContext.Items.Add(value);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}