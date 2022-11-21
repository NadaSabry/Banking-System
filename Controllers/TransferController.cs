using Banking_System.Models;
using Banking_System.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Banking_System.Controllers
{
    public class TransferController : Controller
    {
        private ApplicationDbContext db;
        public TransferController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult AddTransfer(int id)
        {
            AddTransferVM trans = new AddTransferVM();
            trans.customerFrom = db.Customers.Find(id);
            trans.customers = db.Customers.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Name }).ToList();
            return View(trans);
        }
        [HttpPost]
        public IActionResult AddTransfer(int from, int to,int money)
        {
            Transfer tra = new Transfer();
            tra.AmountOfMoney = money;
            tra.Date = DateTime.Now;
            tra.FromId = from;
            tra.ToId = to;
            db.Transfers.Add(tra);
            db.SaveChanges();

            Customer cus1 = db.Customers.Find(from);
            cus1.Balance -= money;
            db.Entry(cus1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            Customer cus2 = db.Customers.Find(to);
            cus2.Balance += money;
            db.Entry(cus2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public IActionResult DisplayTransfer()
        {
            IEnumerable<Transfer> transfer = db.Transfers.Include(e => e.customerFrom).Include(e =>e.customerTo).ToList();
            return View(transfer);
        }
    }
}
