using CDWebShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CDWebShop.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customer
        public async Task<ActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }
    }
}