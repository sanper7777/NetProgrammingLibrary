using Microsoft.AspNetCore.Mvc;
using SimpleMVC.Data;
using SimpleMVC.Models;

namespace SimpleMVC.Controllers
{
    [Route("[controller]")]
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpenseController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Expenses);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense value)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Expenses.Add(value);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(value);
            
        }
    }
}