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
    public class DiskController : Controller
    {
        ApplicationDbContext _context;
        public DiskController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Disk
        public async Task<ViewResult> Index()
        {
            return View(await _context.Disks.Include(x => x.Category).Include(x => x.DiskType).ToListAsync());
        }
    }
}