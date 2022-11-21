using Banking_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Banking_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Customer> customers = db.Customers.ToList();
            return View(customers);
        }
        public IActionResult Profile(int id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}